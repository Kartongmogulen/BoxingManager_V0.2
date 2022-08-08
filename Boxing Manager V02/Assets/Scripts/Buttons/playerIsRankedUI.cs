using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerIsRankedUI : MonoBehaviour
{
    //När spelaren blir Rankad. Ska möta alla motståndare i ordning

    public GameObject OpponentChoosePanelGO;
    public GameObject fightScriptsGO;
    public GameObject buttonOne;
    public GameObject buttonTwo;
    public GameObject buttonThree;
    public GameObject buttonRanked;

    public void playerCanOnlyChooseOneOpponent()
    {
        buttonOne.SetActive(false);
        buttonTwo.SetActive(false);
        buttonThree.SetActive(false);
        buttonRanked.SetActive(true);
    }
}
