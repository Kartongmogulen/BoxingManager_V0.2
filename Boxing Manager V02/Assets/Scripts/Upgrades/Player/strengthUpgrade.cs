using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strengthUpgrade : MonoBehaviour
{
    public player playerOne;

    public void addStrength()
    {
        if (playerOne.expPointsNow > 0)
        {
            playerOne.strength++;
            playerOne.expPointsNow--;
            GetComponent<playerStatsUIController>().updateText();
        }
        else
            return;
    }

    public void subStrength()
    {
        if (playerOne.strength > 0 && playerOne.strength > playerOne.strengthStatAfterLastFight)
        {
            playerOne.strength--;
            playerOne.expPointsNow++;
            GetComponent<playerStatsUIController>().updateText();
        }
        else
            return;
    }
}
