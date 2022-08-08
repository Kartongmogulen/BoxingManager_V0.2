using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponentChooseButton : MonoBehaviour
{
    public GameObject playerListRandoms;
    public GameObject fightUIScriptsGO;
    public GameObject fightScriptsGO;

    public void chooseOpponentOne()
    {
        fightUIScriptsGO.GetComponent<opponentStatsDisplayPanel>().updateOpponentRandom(0);
        fightScriptsGO.GetComponent<fightManager>().setOpponentIndex(0);
    }

    public void chooseOpponentTwo()
    {
        fightUIScriptsGO.GetComponent<opponentStatsDisplayPanel>().updateOpponentRandom(1);
        fightScriptsGO.GetComponent<fightManager>().setOpponentIndex(1);
    }

    public void chooseOpponentThree()
    {
        fightUIScriptsGO.GetComponent<opponentStatsDisplayPanel>().updateOpponentRandom(2);
        fightScriptsGO.GetComponent<fightManager>().setOpponentIndex(2);
    }

    public void chooseOpponentRanked()
    {
        fightUIScriptsGO.GetComponent<opponentStatsDisplayPanel>().updateOpponent();
        //fightScriptsGO.GetComponent<fightManager>().setOpponentIndex(0);
        //Debug.Log("Ranked");
    }
}
