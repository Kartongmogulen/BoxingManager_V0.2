using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorecardManager : MonoBehaviour
{
    /// <summary>
    /// Hanterar rondresultat och vem som vinner
    /// </summary>

    public fightManager FightManager;

    public player PlayerOne;
    public player PlayerTwo;

    public List<int> scoreRoundPlayerOne;
    public List<int> scoreRoundPlayerTwo;

    public int diffKnockdownsPlayerOneMinusPlayerTwo;

    //Spelare 1
    public int knockdownsCounterPlayerOne; //Antal ggr spelaren blivit knockad
    public int knockdownsDuringRoundPlayerOne; //Antal ggr spelaren blivit knockad
    public int knockdownsDuringRoundBeforePlayerOne; //Antal ggr spelaren blivit knockad föregående rond
    public int damageDuringRoundPlayerOne;
    public int totalScorePlayerOne;
    public bool playerOneWonOnDecision;

    //Spelare 2
    public int knockdownsCounterPlayerTwo; //Antal ggr spelaren blivit knockad
    public int knockdownsDuringRoundPlayerTwo; //Antal ggr spelaren blivit knockad
    public int knockdownsDuringRoundBeforePlayerTwo; //Antal ggr spelaren blivit knockad föregående rond
    public int damageDuringRoundPlayerTwo;
    public int totalScorePlayerTwo;

    private void Start()
    {
        FightManager = GetComponent<fightManager>();
    }

    public void compareKnockdowns()
    {
        PlayerTwo = FightManager.PlayerTwo;
        //Spelare 1
        knockdownsCounterPlayerOne = PlayerOne.knockdownCounter;
        knockdownsDuringRoundPlayerOne = knockdownsCounterPlayerOne - knockdownsDuringRoundBeforePlayerOne;
        knockdownsDuringRoundBeforePlayerOne = knockdownsDuringRoundPlayerOne;

        //Spelare 2
        knockdownsCounterPlayerTwo = PlayerTwo.knockdownCounter;
        knockdownsDuringRoundPlayerTwo = knockdownsCounterPlayerTwo - knockdownsDuringRoundBeforePlayerTwo;
        knockdownsDuringRoundBeforePlayerTwo = knockdownsDuringRoundPlayerTwo;

        diffKnockdownsPlayerOneMinusPlayerTwo = knockdownsDuringRoundPlayerOne - knockdownsDuringRoundPlayerTwo;
        scoreRound();
    }

    public void scoreRound()
    {
        //Debug.Log("Diff knockdown: " + diffKnockdownsPlayerOneMinusPlayerTwo);
        if (diffKnockdownsPlayerOneMinusPlayerTwo < 0)
        {
            scoreRoundPlayerOne.Add(10);
            scoreRoundPlayerTwo.Add(9 + diffKnockdownsPlayerOneMinusPlayerTwo);
        }

        if (diffKnockdownsPlayerOneMinusPlayerTwo > 0)
        {
            scoreRoundPlayerTwo.Add(10);
            scoreRoundPlayerOne.Add(9 - diffKnockdownsPlayerOneMinusPlayerTwo);
        }
      
        if (diffKnockdownsPlayerOneMinusPlayerTwo == 0)
        {
            compareDamageRound();
        }

        PlayerOne.damageTakenDuringRound = 0;
        PlayerTwo.damageTakenDuringRound = 0;

    }

    //Jämför vem som orsakat mest skada
    public void compareDamageRound()
    {
        damageDuringRoundPlayerOne = PlayerOne.damageTakenDuringRound;
        damageDuringRoundPlayerTwo = PlayerTwo.damageTakenDuringRound;
        
        if (damageDuringRoundPlayerOne > damageDuringRoundPlayerTwo)
        {
            scoreRoundPlayerOne.Add(9);
            scoreRoundPlayerTwo.Add(10);
        }

        if (damageDuringRoundPlayerOne < damageDuringRoundPlayerTwo)
        {
            scoreRoundPlayerOne.Add(10);
            scoreRoundPlayerTwo.Add(9);
        }

        if (damageDuringRoundPlayerOne == damageDuringRoundPlayerTwo)
        {
            scoreRoundPlayerOne.Add(10);
            scoreRoundPlayerTwo.Add(10);
        }
    }

    public bool scorecardToGetWinner()
    {
      
        for (int i = 0;  i < scoreRoundPlayerOne.Count; i++)
        {
            totalScorePlayerOne += scoreRoundPlayerOne[i];
            totalScorePlayerTwo += scoreRoundPlayerTwo[i];
        }

        if (totalScorePlayerOne > totalScorePlayerTwo) 
        {
            playerOneWonOnDecision = true;
        }
        else
        {
            playerOneWonOnDecision = false;
        }
        return playerOneWonOnDecision;
    }

    //Nollställer scorecard inför fight
    public void resetAfterFight()
    {
        scoreRoundPlayerOne = new List<int> ();
        scoreRoundPlayerTwo = new List<int>();
    }

}
