using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rankingManager : MonoBehaviour
{
    //Hanterar Ranking systemet

    public int playerRankedLvl; //Vilken nivå spelaren är på. Orankad Börjar på 0.
    public int playerRankedLvlForBelt; //När spelaren är Rankad och slås för bältet
    public int limitToRankUpPlayer; //Antal fler segrar än förluster.

    public int rankedForFirstTime;

    public createOpponentAttributeList CreateOpponentAttributeListSO;
    public bool playerRanked;

    public GameObject playerPanelUIGO;
    public GameObject fightScriptsGO;

    public void checkIfPlayerWillRankUp(int pointsNowPlayer)
    {
        //Debug.Log("Kontrollera om spelaren rankar upp script");
        //Debug.Log("Rank gräns: " + (limitToRankUpPlayer * playerRankedLvl + limitToRankUpPlayer));
        if (limitToRankUpPlayer * playerRankedLvl + limitToRankUpPlayer <= pointsNowPlayer)
        {
            playerRankedLvl++;
            //Debug.Log("Rank up!");
        }

        //Debug.Log("Längd: " + CreateOpponentAttributeListSO.accuracyAndStrengthPointsToShare.Length);
        //Blir Spelaren Rankad.
        if (playerRankedLvl >= CreateOpponentAttributeListSO.accuracyAndStrengthPointsToShare.Length)
        {
            Debug.Log("Spelaren är nu RANKAD");
            playerRanked = true;

        }

        if (playerRanked == true)
        {
            rankedForFirstTime++;
            playerPanelUIGO.GetComponent<playerIsRankedUI>().playerCanOnlyChooseOneOpponent();
        }

        
        if (playerRanked == true && rankedForFirstTime == 1)
        {
            //fightScriptsGO.GetComponent<fightManager>().setOpponentIndex(1);
            Debug.Log("Ranked First Time");
        }
    }
}
