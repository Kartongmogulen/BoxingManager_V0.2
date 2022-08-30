using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rankingManager : MonoBehaviour
{
    //Hanterar Ranking systemet

    public int lvlBeforeBecomingRanked; //Antal niv�er Spelaren m�ter "Orankat" motst�nd.

    public int playerRankedLvl; //Vilken niv� spelaren �r p�. Orankad B�rjar p� 0.
    public int playerRankedLvlForBelt; //N�r spelaren �r Rankad och sl�s f�r b�ltet
    public int limitToRankUpPlayer; //Antal fler segrar �n f�rluster.

    public int rankedForFirstTime;

    public createOpponentAttributeList CreateOpponentAttributeListSO;
    public GameObject playerListChampionsFixed;
    public bool playerRanked;

    public GameObject playerPanelUIGO;
    public GameObject fightScriptsGO;

    //START ENDAST F�R TEST
    public void Start()
    {
        checkIfPlayerWillRankUp(0);
    }

    public void checkIfPlayerWillRankUp(int pointsNowPlayer)
    {
        //Debug.Log("Kontrollera om spelaren rankar upp script");
        //Debug.Log("Rank gr�ns: " + (limitToRankUpPlayer * playerRankedLvl + limitToRankUpPlayer));
        if (limitToRankUpPlayer * playerRankedLvl + limitToRankUpPlayer <= pointsNowPlayer)
        {
            playerRankedLvl++;
            //Debug.Log("Rank up!");
        }

        //Debug.Log("L�ngd: " + CreateOpponentAttributeListSO.accuracyAndStrengthPointsToShare.Length);
        
        //Blir Spelaren Rankad.
        if (playerRankedLvl >= lvlBeforeBecomingRanked)
        {
            //Debug.Log("Spelaren �r nu RANKAD");
            playerRanked = true;

        }

        if (playerRanked == true)
        {
            rankedForFirstTime++;
            playerPanelUIGO.GetComponent<playerIsRankedUI>().playerCanOnlyChooseOneOpponent();

        }

        
        if (playerRanked == true && rankedForFirstTime == 1)
        {
            fightScriptsGO.GetComponent<fightManager>().PlayerTwo = playerListChampionsFixed.GetComponent<playerList>().PlayerList[0];
            //Debug.Log("Ranked First Time");
        }
    }
}
