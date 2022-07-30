using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fightManager : MonoBehaviour
{
    public int roundFightLength; //Antal ronder i fighten
    public int roundActionsPerRound; //Antal aktioner varje spelare får göra innan ronden är slut
    public int totalKnockdownCountBeforeStop; //Antal knockdown för att inte ta sig upp
    public bool skipKnockDownCounter; //Vid knockdown. Räknar inte utan får se resultat direkt

    public bool endOfFight; //Om sant = slut på matchen.

    public player PlayerOne;
    public TextMeshProUGUI HeadHealthTextPlayerOne;
    public TextMeshProUGUI BodyHealthTextPlayerOne;
    public TextMeshProUGUI StaminaHealthTextPlayerOne;
    public bool playerOnesTurn; //Om det är spelarens eller datorns tur
    public bool delayPlayerOneAction; //Om false ska det vara en fördröjning
    public bool delayPlayerTwoAction; //Om false ska det vara en fördröjning
    public bool simuatePlayerOneAction; //Om true. Spelaren väljer inte attacker själv
    public Text actionPerformedPlayerOne;
    public Text actionSuccededPlayerOne;
    public Text actionFailedPlayerOne;

    public playerList opponentListGO;
    public int opponentIndex;//Vilket index av valbara motståndare som väljs
    public player PlayerTwo;
    public GameObject playerTwoFighterPanelGO;
    public TextMeshProUGUI nameTextPlayerTwo;
    public TextMeshProUGUI BodyHealthTextPlayerTwo;
    public TextMeshProUGUI HeadHealthTextPlayerTwo;
    public TextMeshProUGUI StaminaHealthTextPlayerTwo;
    public bool knockdownState;
    public Text actionPerformedPlayerTwo;
    public Text actionSuccededPlayerTwo;
    public Text actionFailedPlayerTwo;

    public GameObject fightUIScripts;
    public GameObject fightPanelGO;
    public GameObject victoryPanelGO;
    public GameObject statisticsGO;
    public GameObject playerPanelGO;

    bool actionCompletedOrNot;
    bool actionCompletedOrNotSpecial;
    string head;

    knockdown Knockdown;

    public TextMeshProUGUI actionCompletionText;

    public succedOrNotAction SuccedOrNotAction;

    public playerStatsUIController PlayerStatsUIController;


    public void Start()
    {
        //setUpFight(); //Ska endast vara med då spelaren börjar i en Fight. Annars används Start-knappen för att set-up fight

        Knockdown = GetComponent<knockdown>();
        SuccedOrNotAction = GetComponent<succedOrNotAction>();
        PlayerStatsUIController = playerPanelGO.GetComponent<playerStatsUIController>();

        if (delayPlayerOneAction == false)
        {
            fightUIScripts.GetComponent<commentatorManager>().waitSecondsBeforeUpdatePlayer = 0;
        }
        if (delayPlayerTwoAction == false)
        {
            fightUIScripts.GetComponent<commentatorManager>().waitSecondsBeforeUpdateOpponent = 0;
        }
    }


    public void setUpFight()
    {
        //Debug.Log("Set up Fight");
        playerOnesTurn = true;
        endOfFight = false;
        enableFighterPanel();
        GetComponent<actionsLeftPlayer>().actionPointsNow = GetComponent<actionsLeftPlayer>().actionPointsStart;
        GetComponent<actionsLeftPlayer>().updateText();
        GetComponent<roundManager>().resetRoundAfterFight();
        PlayerTwo = opponentListGO.PlayerList[opponentIndex];
        PlayerTwo.resetAfterFight();
        fightUIScripts.GetComponent<healthPanelTextUpdate>().updatePlayerOneText();
        fightUIScripts.GetComponent<healthPanelTextUpdate>().updateOpponentText();
        fightUIScripts.GetComponent<playerTwoActionDisplay>().resetBetweenFight();
        updateActionsPerformed();
        GetComponent<scorecardManager>().resetAfterFight();

       if (simuatePlayerOneAction == true)
        {
            simulatePlayerOneAction();
        }
    }

    /// <summary>
    /// Sköter hur matcherna hanteras
    /// 1. Val av aktion (Egen funktion)
    /// 2. Beräkning av Träff eller Miss (I funktion i val av aktion, refererar till annat script)
    /// 3. "Spelarnamn" försöker utföra attack X (I funktion i val av aktion, refererar till annat script)
    /// 4. Reducera attackerande spelarens stamina (I funktion i val av aktion, refererar till annat script)
    /// 5. Uppdatera rond-text UI. (I funktion "waitForSecondsFunc" som refererar till annat script)
    /// 6. Inaktiverar panel så spelaren ej kan välja attack (Egen funktion)
    /// 7. Fördröjning (Ligger inom punkt 2 som startar coroutine i annat script)
    /// 8. Uppdatera UI om Träff eller Miss. (Ligger inom punkt 2 som startar coroutine i annat script)
    /// 9.1 Om aktionen lyckas: Reducera försvarandes stats (Annat script)
    /// 9.1.1 Uppdatera texten för försvarande spelare (Egen funktion)
    /// 9.1.2 Någon specialeffekt som ska genomföras? (Annat script)
    /// 9.2 Om aktionen misslyckas: Inget sker
    /// 10. Minska attackerande spelarens Action-Points (afterActionChoicePlayerOne/Two-funktion)
    /// 11. Aktivera panel för spelaren (Om det är Spelarens tur)
    /// 12. Kontrollera om spelaren har Action-Points kvar. 
    /// 12.1 Om inte får motståndaren genomföra sin runda
    /// 
    /// </summary>
    /// 

    public void fightUpdate()
    {
        //Debug.Log("FightUpdateStart");
        //Debug.Log("PlayerOnesTurn: " + playerOnesTurn);
        //GetComponent<actionsLeftPlayer>().subActionPoints();


        //Kontrollera om det är motståndarens tur
        //12. START-------
        //Debug.Log("PlayerOnes Turn: " + playerOnesTurn);
        //Debug.Log("FightState: " + PlayerTwo.fighterStateNow);
        if (playerOnesTurn == false && PlayerTwo.fighterStateNow == fighterState.None && endOfFight == false)
        //12. END -------
        {
            StartCoroutine(waitForSecondsFunc(0, "playerTwoAction")); 
        }

        if (endOfFight == true)
        {
            addStatistics();
        }

        //updateTextHitorNot(actionCompletedOrNot);
        //GetComponent<roundManager>().afterPlayerAction();

        updatePlayerOne();
        updatePlayerTwo();
    }

    

        IEnumerator checkIfNextRoundCanStart()
    {
        //updateTextHitorNot(actionCompletedOrNot);
        if (PlayerOne.fighterStateNow == fighterState.None && PlayerTwo.fighterStateNow == fighterState.None)
        {
            if (playerOnesTurn == true)
            {
                enableFighterPanel();
                fightUpdate();
                //Debug.Log("FightUpdatePlayerOne");

                if (simuatePlayerOneAction == true)
                {
                    simulatePlayerOneAction();
                }

            }
            if (playerOnesTurn == false)
            {
                StartCoroutine(waitForSecondsFunc(fightUIScripts.GetComponent<commentatorManager>().waitSecondsBeforeUpdateOpponent, "fightUpdateDelay")); //*2
                //fightUpdate();
                //Debug.Log("FightUpdatePlayerTwo: ");
            }
            yield return new WaitForSeconds(fightUIScripts.GetComponent<commentatorManager>().waitSecondsBeforeUpdateSpeedFlow); //* 2);
            //fightUpdate();

        }

        else if (PlayerTwo.fighterStateNow == fighterState.Knockdown)
        {
            disableFighterPanel();
            GetComponent<knockdown>().willPlayerGetUp(PlayerTwo, skipKnockDownCounter);
            PlayerTwo.knockdownCounter++;
            if (skipKnockDownCounter == true)
                yield return new WaitForSeconds(1);
            else
                yield return new WaitForSeconds(Knockdown.timePlayerGetsUp + 1);
         
            StartCoroutine(checkIfNextRoundCanStart());
        }

        else if (PlayerOne.fighterStateNow == fighterState.Knockdown)
        {
            disableFighterPanel();
            GetComponent<knockdown>().willPlayerGetUp(PlayerOne, skipKnockDownCounter);
            PlayerOne.knockdownCounter++;
            actionCompletionText.text = PlayerOne.name + " gets knockdowned!";

            if (skipKnockDownCounter == true)
                yield return new WaitForSeconds(1);
            else
                yield return new WaitForSeconds(Knockdown.timePlayerGetsUp + 1);

            //yield return new WaitForSeconds(Knockdown.timePlayerGetsUp + 1);

            StartCoroutine(checkIfNextRoundCanStart());
        }

        else
        StartCoroutine(waitForSecondsFunc(fightUIScripts.GetComponent<commentatorManager>().waitSecondsBeforeUpdateSpeedFlow, "fightUpdate"));
        //fightUpdate();
            
            
      }

        public void updatePlayerOne()
    {
        fightUIScripts.GetComponent<healthPanelTextUpdate>().updatePlayerOneText();
        PlayerOne.staminaRecoveryMinValue();
        PlayerStatsUIController.fightStatModifierUpdate();

    }

    public void updatePlayerTwo()
    {
        fightUIScripts.GetComponent<healthPanelTextUpdate>().updateOpponentText();
        PlayerTwo.staminaRecoveryMinValue();
        //StartCoroutine(checkIfNextRoundCanStart());
    }

   

    //1. START-----------------------------------------------------------------
    public void playerOneJabHeadMeasure()

    {
        GetComponent<jabFight>().measureJab(PlayerOne, PlayerTwo);
    }

    public void playerTwoJabHeadMeasure()

    {
        GetComponent<jabFight>().measureJab(PlayerTwo, PlayerOne);
    }

    public void playerOneJabKeepDistance()

    {
        GetComponent<jabFight>().keepDistanceJab(PlayerOne, PlayerTwo);
    }

    public void playerTwoJabKeepDistance()

    {
        GetComponent<jabFight>().keepDistanceJab(PlayerTwo, PlayerOne);
    }

    public void playerOneJabHead()
    {
        GetComponent<jabFight>().jabHead(PlayerOne, PlayerTwo);
    }

    /*public void playerOneJabHead()
    {
        //Debug.Log("PlayerOneJabHead");
        //actionCompletedOrNot = GetComponent<jabFight>().jab(PlayerOne, PlayerTwo, true);
        //2.START-----------
        if (PlayerTwo.jabKeepDistanceActive == true)
        {
            actionCompletedOrNot = SuccedOrNotAction.action(PlayerOne.accuracy - PlayerTwo.jabKeepDistanceStatBoost, PlayerTwo.guardHead, true);
        }
        else 
        { 
            actionCompletedOrNot = SuccedOrNotAction.action(PlayerOne.accuracy, PlayerTwo.guardHead, true);
        }
        //2.END-----------

        if (actionCompletedOrNot == true)
        {
            PlayerOne.fightStatisticsNumberOfSuccededActions();
            //9.1 START----------
            PlayerTwo.GetComponent<player>().updateHeadHealth(PlayerOne.jabDamageHead);
            //9.1 END----------

            //3.START-------------------
            fightUIScripts.GetComponent<commentatorManager>().startTimer(PlayerOne, PlayerTwo, true, true, true, false);
        }
        else
        {
            fightUIScripts.GetComponent<commentatorManager>().startTimer(PlayerOne, PlayerTwo, true, true, false, false);
            PlayerOne.fightStatisticsNumberOfFailedActions();
        }
            //3.END-------------------

        //4.START----------
        PlayerOne.GetComponent<player>().updateStamina(PlayerOne.jabStaminaUseHead);
        //4.END----------
        updatePlayerOne();

        afterActionChoicePlayerOne();
    }
    */

    public void playerTwoJabHead()
    {
        //2.START-----------

        if (PlayerOne.jabKeepDistanceActive == true)
        {
            actionCompletedOrNot = SuccedOrNotAction.action(PlayerTwo.accuracy - PlayerOne.jabKeepDistanceStatBoost, PlayerOne.guardHead, true);
        }
        else
        {
            actionCompletedOrNot = SuccedOrNotAction.action(PlayerTwo.accuracy, PlayerOne.guardHead, true);
        }
    
        //2.END-----------

        if (actionCompletedOrNot == true)
        {
            PlayerTwo.fightStatisticsNumberOfSuccededActions();
            //9.1 START----------
            PlayerOne.GetComponent<player>().updateHeadHealth(PlayerTwo.jabDamageHead);
            //9.1 END----------

            //3.START----------
            fightUIScripts.GetComponent<commentatorManager>().startTimer(PlayerTwo, PlayerOne, true, true, true, false);

        }
        else
        {
            fightUIScripts.GetComponent<commentatorManager>().startTimer(PlayerTwo, PlayerOne, true, true, false, false);
            PlayerTwo.fightStatisticsNumberOfFailedActions();
        }
            //3.END-------------------

        fightUIScripts.GetComponent<playerTwoActionDisplay>().updateTextLastActionRound("Jab (Head)", actionCompletedOrNot);
        fightUIScripts.GetComponent<playerTwoActionDisplay>().fightUpdateText(true, true);

        //4.START----------
        PlayerTwo.GetComponent<player>().updateStamina(PlayerTwo.jabStaminaUseHead);
        //4.END----------
        updatePlayerTwo();

        afterActionChoicePlayerTwo();
    }

    public void playerOneCrossHead()
    {
        //2.START-----------
        actionCompletedOrNot = SuccedOrNotAction.action(PlayerOne.accuracy, PlayerTwo.guardHead, true);
        //2.END-----------

        //Träffar slaget
        if (actionCompletedOrNot == true)
        {
            PlayerOne.fightStatisticsNumberOfSuccededActions();
            //9.1 START----------
            PlayerTwo.GetComponent<player>().updateHeadHealth(PlayerOne.crossDamageHead);
            //9.1 END----------

            //9.1.2 START----------
            knockdownState = Knockdown.willPlayerGetKnockdown(PlayerOne, PlayerTwo, true);
            if (knockdownState == true)
            {
                Debug.Log("PlayerTwo KO");
                PlayerTwo.fighterStateUpdate(true);
                fightUIScripts.GetComponent<commentatorManager>().startTimer(PlayerOne, PlayerTwo, true, false, true, true);
                PlayerTwo.GetComponent<fightStatsKnockdownCause>().specialAttackCrossKO();
            }
            //9.1.2 END----------

            //3.START-------------------
            if (knockdownState == false)
            {
                fightUIScripts.GetComponent<commentatorManager>().startTimer(PlayerOne, PlayerTwo, true, false, true, false);
            }
        }
        else
        {
            fightUIScripts.GetComponent<commentatorManager>().startTimer(PlayerOne, PlayerTwo, true, false, false, false);
            PlayerOne.fightStatisticsNumberOfFailedActions();
        }
            //3.END-------------------

        //4.START----------
        PlayerOne.GetComponent<player>().updateStamina(PlayerOne.crossStaminaUseHead);
        //4.END----------
        updatePlayerOne();

        afterActionChoicePlayerOne();

    }

    public void playerTwoCrossHead()
    {
        //2.START-----------
        actionCompletedOrNot = SuccedOrNotAction.action(PlayerTwo.accuracy, PlayerOne.guardHead, true);
        //2.END-----------

        //Träffar slaget
        if (actionCompletedOrNot == true)
        {
            PlayerTwo.fightStatisticsNumberOfSuccededActions();
            //9.1 START----------
            PlayerOne.GetComponent<player>().updateHeadHealth(PlayerTwo.crossDamageHead);
            //statisticsGO.GetComponent<fightStatsKnockdownCause>().specialAttackCrossKO(true, PlayerTwo.name);
            //9.1 END----------

            //9.1.2 START----------
            knockdownState = Knockdown.willPlayerGetKnockdown(PlayerTwo, PlayerOne, true);
            if (knockdownState == true)
            {
                PlayerOne.GetComponent<fightStatsKnockdownCause>().specialAttackCrossKO();
                PlayerOne.fighterStateUpdate(true);
                fightUIScripts.GetComponent<commentatorManager>().startTimer(PlayerTwo, PlayerOne, true, false, true, true);
            }
            //9.1.2 END----------

            //3.START-------------------
            if (knockdownState == false)
            {
                fightUIScripts.GetComponent<commentatorManager>().startTimer(PlayerTwo, PlayerOne, true, false, true, false);
            }
        }
        else
        {
            fightUIScripts.GetComponent<commentatorManager>().startTimer(PlayerTwo, PlayerOne, true, false, false, false);
            PlayerTwo.fightStatisticsNumberOfFailedActions();        
        }
            //3.END-------------------

        fightUIScripts.GetComponent<playerTwoActionDisplay>().updateTextLastActionRound("Cross Head", actionCompletedOrNot);
        fightUIScripts.GetComponent<playerTwoActionDisplay>().fightUpdateText(true, false);

        //4.START----------
        PlayerTwo.GetComponent<player>().updateStamina(PlayerTwo.crossStaminaUseHead);
        //4.END----------
        updatePlayerTwo();

        afterActionChoicePlayerTwo();

    }

    public void playerOneJabBody()
    {

        //2.START-----------
        actionCompletedOrNot = SuccedOrNotAction.action(PlayerOne.accuracy, PlayerTwo.guardBody, false);
        //2.END-----------

        if (actionCompletedOrNot == true)
        {
            PlayerOne.fightStatisticsNumberOfSuccededActions();
            //9.1 START----------
            PlayerTwo.GetComponent<player>().updateBodyHealth(PlayerOne.jabDamageBody);
            PlayerTwo.GetComponent<player>().updateStamina(PlayerOne.jabStaminaDamageBody);
            //9.1 END----------

            //3.START-------------------
            fightUIScripts.GetComponent<commentatorManager>().startTimer(PlayerOne, PlayerTwo, false, true, true, false);
        }
        else
        {
            fightUIScripts.GetComponent<commentatorManager>().startTimer(PlayerOne, PlayerTwo, false, true, false, false);
            PlayerOne.fightStatisticsNumberOfFailedActions();
        }
            //3.END-------------------

        //4.START----------
        PlayerOne.GetComponent<player>().updateStamina(PlayerOne.jabStaminaUseBody);
        //4.END----------
        
        updatePlayerOne();
        afterActionChoicePlayerOne();

    }

    public void playerTwoJabBody()
    {
        //2.START-----------
        actionCompletedOrNot = SuccedOrNotAction.action(PlayerTwo.accuracy, PlayerOne.guardBody, false);
        //2.END-----------

        if (actionCompletedOrNot == true)
        {
            PlayerTwo.fightStatisticsNumberOfSuccededActions();
            //9.1 START----------
            PlayerOne.GetComponent<player>().updateBodyHealth(PlayerTwo.jabDamageBody);
            PlayerOne.GetComponent<player>().updateStamina(PlayerTwo.jabStaminaDamageBody);
            //9.1 END----------

            //3.START-------------------
            fightUIScripts.GetComponent<commentatorManager>().startTimer(PlayerTwo, PlayerOne, false, true, true, false);
        }
        else
        {
            fightUIScripts.GetComponent<commentatorManager>().startTimer(PlayerTwo, PlayerOne, false, true, false, false);
            PlayerTwo.fightStatisticsNumberOfFailedActions();
        }
            //3.END-------------------

        fightUIScripts.GetComponent<playerTwoActionDisplay>().updateTextLastActionRound("Jab Body", actionCompletedOrNot);
        fightUIScripts.GetComponent<playerTwoActionDisplay>().fightUpdateText(false, true);
        //4.START----------
        PlayerTwo.GetComponent<player>().updateStamina(PlayerTwo.jabStaminaUseBody);
        //4.END----------

        updatePlayerTwo();
        afterActionChoicePlayerTwo();

    }

    public void playerOneCrossBody()
    {
        //2.START-----------
        actionCompletedOrNot = SuccedOrNotAction.action(PlayerOne.accuracy, PlayerTwo.guardBody, false);
        //2.END-----------

        //Träffar slaget
        if (actionCompletedOrNot == true)
        {
            PlayerOne.fightStatisticsNumberOfSuccededActions();
            //9.1 START----------
            PlayerTwo.GetComponent<player>().updateBodyHealth(PlayerOne.crossDamageBody);
            PlayerTwo.GetComponent<player>().updateStamina(PlayerOne.crossStaminaDamageBody);
            //9.1 END----------

            //9.1.2 START----------Specialattack
            actionCompletedOrNot = SuccedOrNotAction.action(PlayerOne.reduceOpponentStaminaRecoveryChance, PlayerTwo.guardBody, false);
            //Debug.Log(PlayerOne.reduceOpponentStaminaRecoveryChance);
            if (actionCompletedOrNot == true)
            {
                PlayerTwo.staminaRecoveryBetweenRounds--;
                fightUIScripts.GetComponent<commentatorManager>().startTimer(PlayerOne, PlayerTwo, false, false, true, true);
                //9.1.2 END----------
            }
            else
            {
                //3.START-------------------
                fightUIScripts.GetComponent<commentatorManager>().startTimer(PlayerOne, PlayerTwo, false, false, true, false);
            }

        }
        else
        {
            fightUIScripts.GetComponent<commentatorManager>().startTimer(PlayerOne, PlayerTwo, false, false, false, true);
            PlayerOne.fightStatisticsNumberOfFailedActions();
        }
            //3.END-------------------

        //4.START----------
        PlayerOne.GetComponent<player>().updateStamina(PlayerOne.crossStaminaUseBody);
        //4.END----------
        updatePlayerOne();

        afterActionChoicePlayerOne();

    }

    public void playerTwoCrossBody()
    {

        //2.START-----------
        actionCompletedOrNot = SuccedOrNotAction.action(PlayerTwo.accuracy, PlayerOne.guardBody, false);
        //2.END-----------

        //Träffar slaget
        if (actionCompletedOrNot == true)
        {
            PlayerTwo.fightStatisticsNumberOfSuccededActions();
            //Debug.Log("PlayerTwo BodyCross Hit");
            //9.1 START----------
            PlayerOne.GetComponent<player>().updateBodyHealth(PlayerTwo.crossDamageBody);
            PlayerOne.GetComponent<player>().updateStamina(PlayerTwo.crossStaminaDamageBody);
            //9.1 END----------

            //9.1.2 START----------Specialattack
            actionCompletedOrNotSpecial = SuccedOrNotAction.action(PlayerTwo.reduceOpponentStaminaRecoveryChance, PlayerOne.guardBody, false);
            //Debug.Log(PlayerOne.reduceOpponentStaminaRecoveryChance);
            if (actionCompletedOrNotSpecial == true)
            {
                PlayerOne.staminaRecoveryBetweenRounds--;
                fightUIScripts.GetComponent<commentatorManager>().startTimer(PlayerTwo, PlayerOne, false, false, true, true);
            }
            else
            {
                //3.START-------------------
                fightUIScripts.GetComponent<commentatorManager>().startTimer(PlayerTwo, PlayerOne, false, false, true, false);
            }

        }
        else
        {
            fightUIScripts.GetComponent<commentatorManager>().startTimer(PlayerTwo, PlayerOne, false, false, false, true);
            PlayerTwo.fightStatisticsNumberOfFailedActions();
        }
            //3.END-------------------

        fightUIScripts.GetComponent<playerTwoActionDisplay>().updateTextLastActionRound("Cross Body", actionCompletedOrNot);
        fightUIScripts.GetComponent<playerTwoActionDisplay>().fightUpdateText(false, false);
        //4.START----------
        PlayerTwo.GetComponent<player>().updateStamina(PlayerTwo.crossStaminaUseBody);
        //4.END----------
        updatePlayerTwo();

        afterActionChoicePlayerTwo();


        /*
        actionCompletedOrNot = GetComponent<crossFight>().cross(PlayerTwo, PlayerOne, false);

        PlayerTwo.GetComponent<player>().updateStamina(PlayerTwo.crossStaminaUseBody);
        updatePlayerTwo();

        if (actionCompletedOrNot == true)
        {
            PlayerOne.GetComponent<player>().updateBodyHealth(PlayerTwo.crossDamageBody);
            PlayerOne.GetComponent<player>().updateStamina(PlayerTwo.crossStaminaDamageBody);
            PlayerOne.staminaRecoveryBetweenRounds -= PlayerTwo.crossStaminaRecoveryDamageBody;
        }

        updatePlayerOne();
        */
    }
    //1. END --------------------------------------------------------
    /*public void updateTextHitorNot(bool completion) 
    {
        if (completion == true)
        {
            actionCompletionText.text = "HIT";

            if (PlayerTwo.fighterStateNow == fighterState.Knockdown)
            {
               //actionCompletionText.text = PlayerTwo.name + " gets knockdowned!";
               //GetComponent<knockdown>().willPlayerGetUp(PlayerTwo);
               //PlayerTwo.knockdownCounter++;
            }

            if (PlayerOne.fighterStateNow == fighterState.Knockdown)
            {
                actionCompletionText.text = PlayerOne.name + " gets knockdowned!";

            }
        }

        else
            actionCompletionText.text = "MISS";

    }
    */

    IEnumerator waitForSecondsFunc(int seconds, string functionName)
    {

        yield return new WaitForSeconds(seconds);
        if (functionName == "updatePlayerTwoFunc")
        {
            //Debug.Log("UpdatePlayer2");
            updatePlayerTwo();
            StartCoroutine(checkIfNextRoundCanStart());
            //5.START--------
            GetComponent<roundManager>().afterPlayerAction();
            //5.END--------
        }

        if (functionName == "updatePlayerOneFunc")
        {
            updatePlayerOne();
            StartCoroutine(checkIfNextRoundCanStart());
            //5.START--------
            GetComponent<roundManager>().afterPlayerAction();
            //5.END--------

        }

        if (functionName == "fightUpdateDelay")
        {
     
            fightUpdate();
            
        }

        if (functionName == "playerTwoAction")
        {
            /*
            if (PlayerTwo.GetComponent<player>().fightStyleNow == fightStyle.Headhunter)
            {
                GetComponent<playerTwoAction>().headHunter();
            }

            if (PlayerTwo.GetComponent<player>().fightStyleNow == fightStyle.BodySnatcher)
            {
                GetComponent<playerTwoAction>().bodySnatcher();
            }
            */

            //TEST

            //GetComponent<playerTwoAction>().jabHead();
            //GetComponent<playerTwoAction>().crossHead();
            //GetComponent<playerTwoAction>().randomizedHead();
            //GetComponent<playerTwoAction>().jabBody();
            //GetComponent<playerTwoAction>().crossBody();
            //GetComponent<playerTwoAction>().onlyJabMeasure();
            //GetComponent<playerTwoAction>().onlyJabKeepDistance();
            GetComponent<playerTwoAction>().test();
        }

    }

    //6.START--------------
    void disableFighterPanel()
    {
        playerTwoFighterPanelGO.active = false;
    }
    //6.END--------------

    

    //10. START--------------
    public void afterActionChoicePlayerOne()
    {
        StartCoroutine(waitForSecondsFunc(fightUIScripts.GetComponent<commentatorManager>().waitSecondsBeforeUpdatePlayer * 2, "updatePlayerTwoFunc"));
        disableFighterPanel();
        GetComponent<actionsLeftPlayer>().subActionPoints();
        PlayerOne.fightStatisticsNumberOfActions();
        actionPerformedPlayerOne.text = "Action performed: " + PlayerOne.actionsPerformed;
        actionSuccededPlayerOne.text = "Action succeded: " + PlayerOne.actionsSucceded;
        actionFailedPlayerOne.text = "Action failed: " + PlayerOne.actionsFailed;

    }

    public void afterActionChoicePlayerTwo()
    {
        StartCoroutine(waitForSecondsFunc(fightUIScripts.GetComponent<commentatorManager>().waitSecondsBeforeUpdateOpponent * 2, "updatePlayerOneFunc"));
        GetComponent<actionsLeftPlayer>().subActionPoints();
        PlayerTwo.fightStatisticsNumberOfActions();
        actionPerformedPlayerTwo.text = "Action performed: " + PlayerTwo.actionsPerformed;
        actionSuccededPlayerTwo.text = "Action succeded: " + PlayerTwo.actionsSucceded;
        actionFailedPlayerTwo.text = "Action failed: " + PlayerTwo.actionsFailed;
    }
    //10. END--------------

    //11. START---------
    void enableFighterPanel()
    {
        playerTwoFighterPanelGO.active = true;

    }
    //11. END---------

        //Stoppa simulering när matchen är slut
    public void fightEndedKO(player playerWhoLost)
    {
        endOfFight = true;
        fightPanelGO.active = false;
        victoryPanelGO.active = true;
        if (playerWhoLost == PlayerTwo)
        {
            victoryPanelGO.GetComponent<afterFightUpdate>().updateText(PlayerOne, true);
            rankUpPlayer();
            statisticsGO.GetComponent<fightStatistics>().addVictory();
        }
        else
        {
            victoryPanelGO.GetComponent<afterFightUpdate>().updateText(PlayerOne, false);
            statisticsGO.GetComponent<fightStatistics>().addLose();
        }
        statisticsGO.GetComponent<fightStatistics>().addKO();
    
        PlayerOne.resetAfterFight();
        PlayerTwo.resetAfterFight();
    }

    public void fightEndedDecision()
    {
        endOfFight = true;
        fightPanelGO.active = false;
        victoryPanelGO.active = true;

        if (GetComponent<roundManager>().playerOneWonOnDecision == true)
        {
            victoryPanelGO.GetComponent<afterFightUpdate>().decisionUpdate(true);
            rankUpPlayer();
            statisticsGO.GetComponent<fightStatistics>().addVictory();
        }
        else
        {
            victoryPanelGO.GetComponent<afterFightUpdate>().decisionUpdate(false);
            statisticsGO.GetComponent<fightStatistics>().addLose();
        }
        statisticsGO.GetComponent<fightStatistics>().addDecision();

        PlayerOne.resetAfterFight();
        PlayerTwo.resetAfterFight();
    }

    public void rankUpPlayer()
    {
       
        opponentIndex++;
        Debug.Log(opponentIndex);
        Debug.Log(opponentListGO.PlayerList.Count);
        if (opponentIndex >= opponentListGO.PlayerList.Count)
        {
            victoryPanelGO.GetComponent<afterFightUpdate>().updateTextChampion(PlayerOne);
        }
        else
        {
            fightUIScripts.GetComponent<opponentStatsDisplayPanel>().updateOpponent();
        }
        
    }

    public void simulatePlayerOneAction()
    {
        //playerOneJabHead();
        playerOneCrossHead();
    }

    public void addStatistics()
    {
        GetComponent<roundManager>().addStatisticFightEndedRound();
    }

    public void updateActionsPerformed()
    {
        actionPerformedPlayerOne.text = "Action performed: " + PlayerOne.actionsPerformed;
        actionSuccededPlayerOne.text = "Action succeded: " + PlayerOne.actionsSucceded;
        actionFailedPlayerOne.text = "Action failed: " + PlayerOne.actionsFailed;

        actionPerformedPlayerTwo.text = "Action performed: " + PlayerTwo.actionsPerformed;
        actionSuccededPlayerTwo.text = "Action succeded: " + PlayerTwo.actionsSucceded;
        actionFailedPlayerTwo.text = "Action failed: " + PlayerTwo.actionsFailed;
    }
}
