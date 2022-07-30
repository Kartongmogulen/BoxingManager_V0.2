using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardHeadUpgrade : MonoBehaviour
{
    public player playerOne;

    public void add()
    {
        if (playerOne.expPointsNow > 0)
        {
            playerOne.guardHead++;
            playerOne.expPointsNow--;
            GetComponent<playerStatsUIController>().updateText();
        }
        else
            return;
    }

    public void sub()
    {
        if (playerOne.guardHead > 0 && playerOne.guardHead > playerOne.guardHeadStatAfterLastFight)
        {
            playerOne.guardHead--;
            playerOne.expPointsNow++;
            GetComponent<playerStatsUIController>().updateText();
        }
        else
            return;
    }
}
