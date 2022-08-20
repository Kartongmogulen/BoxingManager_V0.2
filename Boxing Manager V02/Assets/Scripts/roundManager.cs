using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class roundManager : MonoBehaviour
{
    /*Hanterar
    1. Rondnummer
    2. Klocka
    */

    private int roundFightLength; //Antal ronder i fighten
    public int roundNow;
    private int minInRound; //Antal min som gått i ronden
    private float secInRound; //Antal sekunder som gått i ronden
    private float roundActionsPerPlayer; //Antal aktioner varje spelare får göra innan ronden är slut
    public bool playerOneWonOnDecision;

    public GameObject victoryPanelGO;
    public GameObject statisticsGO;
    public GameObject simPanelGO;

    public TextMeshProUGUI roundClock;
    public TextMeshProUGUI simPanelRoundClock;

    public int bugg_i; //FÖR BUGG
    private void Start()
    {
        roundFightLength = GetComponent<fightManager>().roundFightLength;
        roundActionsPerPlayer = GetComponent<fightManager>().roundActionsPerRound;
        //roundNow = 1;
    }

    public void afterPlayerAction()
    {
        bugg_i++;
        //Debug.Log(bugg_i);

        secInRound += 180 / roundActionsPerPlayer / 2;
        
        if (secInRound>=60)
        {
            minInRound++;
            secInRound = secInRound - 60;
        }

        if (minInRound == 3)
        {
            resetRound();
            
            //Debug.Log("Round now: " + roundNow);
        }

        roundClock.text = "Round: " + roundNow + "  Min: " + minInRound +  " Sec: " + secInRound;
        simPanelRoundClock.text = "Round: " + roundNow + "  Min: " + minInRound + " Sec: " + secInRound;
    }

    //Nollställer vid rondens slut
   public void resetRound()
    {
        //Debug.Log("Round now: " + roundNow);
        roundNow++;
        minInRound = 0;

        GetComponent<betweenRounds>().recoverStats(GetComponent<fightManager>().PlayerTwo);
        GetComponent<scorecardManager>().compareKnockdowns();

        //Matchen har gått tiden ut
        if (roundNow == roundFightLength)
        {
            //Debug.Log("Matchen har gått tiden ut");
            playerOneWonOnDecision = GetComponent<scorecardManager>().scorecardToGetWinner();
            //if (playerOneWonOnDecision == true)
            GetComponent<fightManager>().fightEndedDecision();
            //victoryPanelGO.GetComponent<afterFightUpdate>().decisionUpdate(playerOneWonOnDecision);
        }

        //SIMULERING
        if (GetComponent<fightManager>().simulation == true )
        {
            simPanelGO.GetComponent<simulateFight>().roundEnded = true; //För att kunna simulera en rond
            simPanelGO.GetComponent<simulateFight>().resetDataAfterRound();
            simPanelGO.GetComponent<simulateFight>().startFight();
        }
    }

    public void resetRoundAfterFight()
    {
        //Debug.Log("ResetRoundAfterFight");
        roundNow = 1;
        minInRound = 0;
        secInRound = 0;

        roundClock.text = "Round: " + roundNow + "  Min: " + minInRound + " Sec: " + secInRound;
        simPanelRoundClock.text = "Round: " + roundNow + "  Min: " + minInRound + " Sec: " + secInRound;
    }

    public void addStatisticFightEndedRound()
    {
        statisticsGO.GetComponent<fightStatistics>().addRound(roundNow);
    }
}
