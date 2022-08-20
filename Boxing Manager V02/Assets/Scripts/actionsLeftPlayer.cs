using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class actionsLeftPlayer : MonoBehaviour
{
    public int bytTillSpelareEttInt; //ENDAST FÖR FELSÖKNING
    
    public int actionPointsStart;
    public int actionPointsNow;

    public bool playerOnesTurn;

    public TextMeshProUGUI playersTurnText;

    public GameObject simulationPanelGO;

    public void Start()
    {
        //Om simulering för balansering är aktiverad
        if (simulationPanelGO.GetComponent<simulateFight>().simulationON == true)
        {
            actionPointsStart = simulationPanelGO.GetComponent<simulateFight>().actionPointsStart;
            //simulationPanelGO.GetComponent<simulateFight>().actionPointsNow = actionPointsStart;
        }

        actionPointsNow = actionPointsStart;

        //playerOnesTurn = true;
        playersTurnText.text = "Player One (turns left): " + actionPointsNow;
        //Debug.Log("ActionsPointsLeftStart");
    }

    public void subActionPoints(int actionPoints)
    {
        playerOnesTurn = GetComponent<fightManager>().playerOnesTurn;

        //Debug.Log("PlayerOnesTurn: " + playerOnesTurn);

        actionPointsNow -= actionPoints;
        if (actionPointsNow <= 0)
            resetActionPoints();

        updateText();
        //Debug.Log("Actions Point Left: " + actionPointsNow);
    }

    public void resetActionPoints()
    {
        //Debug.Log("ResetActionPoints");
        actionPointsNow = actionPointsStart;

        if (playerOnesTurn == true)
        {
            GetComponent<fightManager>().playerOnesTurn = false;
            GetComponent<fightManager>().PlayerTwo.jabKeepDistanceActive = false;
        }
        else
        {
            bytTillSpelareEttInt++;
            //Debug.Log("Byt till Spelare ETT: " + bytTillSpelareEttInt);
            
            GetComponent<fightManager>().playerOnesTurn = true;
            GetComponent<fightManager>().PlayerOne.jabKeepDistanceActive = false;
            //GetComponent<simulateFight>().playerOneAndTwoFullTurnSimCheck = true;
        }

        //Debug.Log("PlayerOneKeepDistance: " + GetComponent<fightManager>().PlayerOne.jabKeepDistanceActive);
        //Debug.Log("PlayerTwoKeepDistance: " + GetComponent<fightManager>().PlayerTwo.jabKeepDistanceActive);
    }

    public void updateText()
    {
        playerOnesTurn = GetComponent<fightManager>().playerOnesTurn;
        if (playerOnesTurn == true)
            playersTurnText.text = "Player One (turns left): " + actionPointsNow;
        else
        {
            playersTurnText.text = "Player Two (turns left): " + actionPointsNow;
        }
       
    }
}
