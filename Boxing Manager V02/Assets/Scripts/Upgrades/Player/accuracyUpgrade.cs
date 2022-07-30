using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accuracyUpgrade : MonoBehaviour
{
    public player playerOne;

    public void addAccuracy()
    {
        if (playerOne.expPointsNow > 0)
        {
            playerOne.accuracy++;
            playerOne.expPointsNow--;
            GetComponent<playerStatsUIController>().updateText();
        }
        else
            return;
    }

    public void subAccuracy()
    {
        if (playerOne.accuracy > 0 && playerOne.accuracy > playerOne.accuracyStatAfterLastFight)
        {
            playerOne.accuracy--;
            playerOne.expPointsNow++;
            GetComponent<playerStatsUIController>().updateText();
        }
        else
            return;
    }



}
