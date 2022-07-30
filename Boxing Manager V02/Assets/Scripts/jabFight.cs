using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jabFight : MonoBehaviour
{
    //public int succededActionsMeasure; //Antal lyckade action. Detta som avgör om specialegenskaper funkar

    bool actionCompletedOrNot;

    public succedOrNotAction SuccedOrNotAction;

    public GameObject fightUIScripts;

    private void Start()
    {
        SuccedOrNotAction = GetComponent<succedOrNotAction>();
    }

    public void jabHead(player attacker, player defender)
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
        //3.END-------------------

        //4.START----------
        attacker.GetComponent<player>().updateStamina(attacker.jabStaminaUseLow);
        //4.END----------
        if (attacker.Opponent == false)
        {
            GetComponent<fightManager>().updatePlayerOne();
            GetComponent<fightManager>().afterActionChoicePlayerOne();
        }
        else
        {
            GetComponent<fightManager>().updatePlayerTwo();
            GetComponent<fightManager>().afterActionChoicePlayerTwo();
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

        //3.END-------------------
        //4.START----------
        attacker.GetComponent<player>().updateStamina(attacker.jabStaminaUseLow);
        //4.END----------
        if (attacker.Opponent == false)
        {
            GetComponent<fightManager>().updatePlayerOne();
            GetComponent<fightManager>().afterActionChoicePlayerOne();
        }
        else
        {
            GetComponent<fightManager>().updatePlayerTwo();
            GetComponent<fightManager>().afterActionChoicePlayerTwo();
        }
    }

    //Vid en lyckad aktion/runda minskar motståndaren Accuracy
    public void keepDistanceJab(player attacker, player defender)
    {
        //Lyckas attacken eller inte
        actionCompletedOrNot = SuccedOrNotAction.action(attacker.accuracy + attacker.measureJabIncreaseAccuracyWhenActive, defender.guardHead, true);

        if (actionCompletedOrNot == true)
        {
            attacker.fightStatisticsNumberOfSuccededActions();
            //9.1 START----------
            //Justerar hälsa
            defender.GetComponent<player>().updateHeadHealth(attacker.jabDamageLow);
            //9.1 END----------

            //9.1.2 START--------
            attacker.jabKeepDistanceActive = true;
            Debug.Log("keepdistance: " + attacker.jabKeepDistanceActive);

            //9.1.2 END--------

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
            GetComponent<fightManager>().afterActionChoicePlayerOne();
        }
        else
        {
            GetComponent<fightManager>().updatePlayerTwo();
            GetComponent<fightManager>().afterActionChoicePlayerTwo();
        }

    }

}
