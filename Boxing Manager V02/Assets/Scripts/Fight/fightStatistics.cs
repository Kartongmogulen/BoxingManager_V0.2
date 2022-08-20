using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightStatistics : MonoBehaviour
{
    /// <summary>
    /// HANTERAR OCH SPARAR ALL STATISTIC UNDER MATCHERNA
    /// </summary>

    public List<string> howTheFightEnded; //Hur avgjordes matchen
    public List<string> results; //Seger, Oavgjort, Förlust
    public List<int> roundFightEnded; //Vilken rond matchen avgjordes

    //public List<string> resultHistory;

    public static List<int> fightEndedRound(int fightEndedRound, List<int> roundFightEnded)
    {
        roundFightEnded.Add(fightEndedRound);

        return roundFightEnded;
    }

    public void addRound(int round)
    {
        fightEndedRound(round, roundFightEnded);

    }


    //Hur avgjordes matchen
    public static List<string> addHowTheFightEnded(string fightEndedBy, List<string> howTheFightEnded)
    {
        howTheFightEnded.Add(fightEndedBy);

        return howTheFightEnded;
    }

    public void addKO()
    {
        addHowTheFightEnded("KO", howTheFightEnded);
    }

    public void addDecision()
    {
        addHowTheFightEnded("Decision", howTheFightEnded);
    }

    //Hanterar resultatet (Win, Lose, Draw)

    public static List<string> addResult(string resultText, List<string> results)
    {
        results.Add(resultText);

        return results;
    }


    public void addVictory()
    {
        addResult("W", results);
        
    }

    public void addLose()
    {
        addResult("L", results);
    }

    public void addDraw()
    {
        addResult("D", results);
    }
}
