using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardBodyUpgrade : MonoBehaviour
{
    public player playerOne;
   
    public void add()
    {
        if (playerOne.expPointsNow > 0)
        {
            playerOne.guardBody++;
            playerOne.expPointsNow--;
            GetComponent<playerStatsUIController>().updateText();
        }
        else
            return;
    }

    public void sub()
    {
        if (playerOne.guardBody > 0 && playerOne.guardBody > playerOne.guardBodyStatAfterLastFight)
        {
            playerOne.guardBody--;
            playerOne.expPointsNow++;
            GetComponent<playerStatsUIController>().updateText();
        }
        else
            return;
    }
}
