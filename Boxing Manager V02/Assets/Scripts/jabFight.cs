using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jabFight : MonoBehaviour
{
    //public int succededActionsMeasure; //Antal lyckade action. Detta som avg�r om specialegenskaper funkar

    bool actionCompletedOrNot;

    public succedOrNotAction SuccedOrNotAction;

    public GameObject fightUIScripts;

    public int i;//ENDAST F�R FELS�KNING
    public int singelPunchInt;//ENDAST F�R FELS�KNING

    private void Start()
    {
        SuccedOrNotAction = GetComponent<succedOrNotAction>();
    }

    public void jabHead(player attacker, player defender, bool singelPunch)
    {
        

        //2.START-----------
        if (defender.jabKeepDistanceActive == true)
        {
            actionCompletedOrNot = SuccedOrNotAction.action(attacker.accuracy - defender.jabKeepDistanceStatBoost, defender.guardHead, true);
        }
        else
        {
            actionCompletedOrNot = SuccedOrNotAction.action(attacker.accuracy, defender.guardHead, true);
        }
        //2.END-----------

        if (actionCompletedOrNot == true)
        {
            attacker.fightStatisticsNumberOfSuccededActions();
            //9.1 START----------
            defender.GetComponent<player>().updateHeadHealth(attacker.jabDamageHead);
            //9.1 END----------

            //3.START-------------------

            fightUIScripts.GetComponent<commentatorManager>().startTimer(attacker, defender, true, true, true, false);
        }
        else
        {
            fightUIScripts.GetComponent<commentatorManager>().startTimer(attacker, defender, true, true, false, false);
            attacker.fightStatisticsNumberOfFailedActions();
        }
        fightUIScripts.GetComponent<attackHeadManager>().playerOneJab();
        //3.END-------------------

        //4.START----------
        attacker.GetComponent<player>().updateStamina(attacker.jabStaminaUseHead);
        //4.END----------
       
        //Debug.Log("JabHead: " + i);
        //Debug.Log("Spelare TV� attackerar: " + attacker.Opponent +" " + i);
        //Spelare Ett �r attackerande
        if (attacker.Opponent == false)
        {
            GetComponent<fightManager>().updatePlayerOne();
            //GetComponent<fightManager>().afterActionChoicePlayerOne(1);
            if (singelPunch == true && GetComponent<fightManager>().simulation == false)
            {

                GetComponent<fightManager>().afterActionChoicePlayerOne(1);
                singelPunchInt++;
            }

            
        }

       

        //Spelare Tv� �r attackerande
        else
        {
            i++;
            Debug.Log("SpelareTv�sTur innan UpdatePlayerTwo");
            GetComponent<fightManager>().updatePlayerTwo();
            //GetComponent<fightManager>().afterActionChoicePlayerTwo();
            if (singelPunch == true)
            {
                //Debug.Log("JabFight-script - Jab");
                GetComponent<fightManager>().afterActionChoicePlayerTwo(1);
            }
        }

    }

    public void measureJab(player attacker, player defender)
    {
        actionCompletedOrNot = SuccedOrNotAction.action(attacker.accuracy + attacker.measureJabIncreaseAccuracyWhenActive, defender.guardHead, true);
        
        if (actionCompletedOrNot == true)
        {
            attacker.fightStatisticsNumberOfSuccededActions();
            //9.1 START----------
            defender.GetComponent<player>().updateHeadHealth(attacker.jabDamageLow);
            //9.1 END----------

            //9.1.2 START--------
            attacker.measureJabSuccededDurigFight++;

            if (attacker.measureJabSuccededDurigFight >= attacker.measureJabLimit)
                attacker.measureJabIncreaseAccuracyWhenActive = attacker.measureJabPotentialIncreaseAccuracy;
            //9.1.2 END--------

            //3.START-------------------
            fightUIScripts.GetComponent<commentatorManager>().startTimer(attacker, defender, true, true, true, false);
        }
        else
        {
            fightUIScripts.GetComponent<commentatorManager>().startTimer(attacker, defender, true, true, false, false);
            attacker.fightStatisticsNumberOfFailedActions();
        }
        fightUIScripts.GetComponent<attackHeadManager>().playerOneJab();
        //3.END-------------------
        //4.START----------
        attacker.GetComponent<player>().updateStamina(attacker.jabStaminaUseLow);
        //4.END----------
        if (attacker.Opponent == false)
        {
            GetComponent<fightManager>().updatePlayerOne();
            GetComponent<fightManager>().afterActionChoicePlayerOne(1);
        }
        else
        {
            GetComponent<fightManager>().updatePlayerTwo();
            GetComponent<fightManager>().afterActionChoicePlayerTwo(1);
        }
    }

    //Vid en lyckad aktion/runda minskar motst�ndaren Accuracy
    public void keepDistanceJab(player attacker, player defender)
    {
        //Lyckas attacken eller inte
        actionCompletedOrNot = SuccedOrNotAction.action(attacker.accuracy + attacker.measureJabIncreaseAccuracyWhenActive, defender.guardHead, true);

        if (actionCompletedOrNot == true)
        {
            attacker.fightStatisticsNumberOfSuccededActions();
            //9.1 START----------
            //Justerar h�lsa
            defender.GetComponent<player>().updateHeadHealth(attacker.jabDamageLow);
            //9.1 END----------

            //9.1.2 START--------
            attacker.jabKeepDistanceActive = true;
            Debug.Log("keepdistance: " + attacker.jabKeepDistanceActive);

            //9.1.2 END--------
            fightUIScripts.GetComponent<attackHeadManager>().playerOneJab();
            //3.START-------------------
            fightUIScripts.GetComponent<commentatorManager>().startTimer(attacker, defender, true, true, true, false);
        }
        else
        {
            fightUIScripts.GetComponent<commentatorManager>().startTimer(attacker, defender, true, true, false, false);
            attacker.fightStatisticsNumberOfFailedActions();
        }

        //3.END-------------------
        //4.START----------
        attacker.GetComponent<player>().updateStamina(attacker.jabStaminaUseHead);
        //4.END----------

        if (attacker.Opponent == false)
        {
            GetComponent<fightManager>().updatePlayerOne();
            GetComponent<fightManager>().afterActionChoicePlayerOne(1);
        }
        else
        {
            GetComponent<fightManager>().updatePlayerTwo();
            GetComponent<fightManager>().afterActionChoicePlayerTwo(1);
        }

    }

    public void jabBody(player attacker, player defender, bool singelPunch)
    {


        //2.START-----------
        if (defender.jabKeepDistanceActive == true)
        {
            actionCompletedOrNot = SuccedOrNotAction.action(attacker.accuracy - defender.jabKeepDistanceStatBoost, defender.guardBody, true);
        }
        else
        {
            actionCompletedOrNot = SuccedOrNotAction.action(attacker.accuracy, defender.guardBody, true);
        }
        //2.END-----------

        if (actionCompletedOrNot == true)
        {
            attacker.fightStatisticsNumberOfSuccededActions();
            //9.1 START----------
            defender.GetComponent<player>().updateBodyHealth(attacker.jabDamageBody);
            defender.GetComponent<player>().updateStamina(attacker.jabStaminaDamageBody);
            //9.1 END----------

            //3.START-------------------

            fightUIScripts.GetComponent<commentatorManager>().startTimer(attacker, defender, false, true, true, false);
        }
        else
        {
            fightUIScripts.GetComponent<commentatorManager>().startTimer(attacker, defender, false, true, false, false);
            attacker.fightStatisticsNumberOfFailedActions();
        }
        //fightUIScripts.GetComponent<attackHeadManager>().playerOneJab();
        //3.END-------------------

        //4.START----------
        attacker.GetComponent<player>().updateStamina(attacker.jabStaminaUseBody);
        //4.END----------

        //Spelare Ett �r attackerande
        if (attacker.Opponent == false)
        {
            GetComponent<fightManager>().updatePlayerOne();
         
            if (singelPunch == true && GetComponent<fightManager>().simulation == false)
            { 
                GetComponent<fightManager>().afterActionChoicePlayerOne(1);
                singelPunchInt++;
            }


        }

        //Spelare Tv� �r attackerande
        else
        {
            i++;
            Debug.Log("SpelareTv�sTur innan UpdatePlayerTwo");
            GetComponent<fightManager>().updatePlayerTwo();
            //GetComponent<fightManager>().afterActionChoicePlayerTwo();
            if (singelPunch == true)
            {
                //Debug.Log("JabFight-script - Jab");
                GetComponent<fightManager>().afterActionChoicePlayerTwo(1);
            }
        }

    }

}
