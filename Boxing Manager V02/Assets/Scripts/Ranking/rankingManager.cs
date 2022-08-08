using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rankingManager : MonoBehaviour
{
    //Hanterar Ranking systemet

    public int playerRankedLvl; //Vilken niv� spelaren �r p�. Orankad B�rjar p� 0.
    public int playerRankedLvlForBelt; //N�r spelaren �r Rankad och sl�s f�r b�ltet
    public int limitToRankUpPlayer; //Antal fler segrar �n f�rluster.

    public int rankedForFirstTime;

    public createOpponentAttributeList CreateOpponentAttributeListSO;
    public bool playerRanked;

    public GameObject playerPanelUIGO;
    public GameObject fightScriptsGO;

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
        if (playerRankedLvl >= CreateOpponentAttributeListSO.accuracyAndStrengthPointsToShare.Length)
        {
            Debug.Log("Spelaren �r nu RANKAD");
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
