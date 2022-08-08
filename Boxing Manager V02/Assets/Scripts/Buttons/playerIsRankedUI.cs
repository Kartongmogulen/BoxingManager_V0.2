using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerIsRankedUI : MonoBehaviour
{
    //N�r spelaren blir Rankad. Ska m�ta alla motst�ndare i ordning

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
