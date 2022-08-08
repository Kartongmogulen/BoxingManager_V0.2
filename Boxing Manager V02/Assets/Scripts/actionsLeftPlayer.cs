using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class actionsLeftPlayer : MonoBehaviour
{
    public int actionPointsStart;
    public int actionPointsNow;

    public bool playerOnesTurn;

    public TextMeshProUGUI playersTurnText;

    public void Start()
    {
        actionPointsNow = actionPointsStart;
       //playerOnesTurn = true;
        playersTurnText.text = "Player One (turns left): " + actionPointsNow;
    }

    public void subActionPoints(int actionPoints)
    {
        playerOnesTurn = GetComponent<fightManager>().playerOnesTurn;
 
        actionPointsNow -= actionPoints;
        if (actionPointsNow <= 0)
            resetActionPoints();

        updateText();

    }

    public void resetActionPoints()
    {
      
        actionPointsNow = actionPointsStart;

        if (playerOnesTurn == true)
        {
            GetComponent<fightManager>().playerOnesTurn = false;
            GetComponent<fightManager>().PlayerTwo.jabKeepDistanceActive = false;
        }
        else
        {
            GetComponent<fightManager>().playerOnesTurn = true;
            GetComponent<fightManager>().PlayerOne.jabKeepDistanceActive = false;
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
