using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockdownChanceUpgrade : MonoBehaviour
{
    public player playerOne;

    public void add()
    {
        if (playerOne.expPointsNow > 0)
        {
            playerOne.knockdownChance++;
            playerOne.expPointsNow--;
            GetComponent<playerStatsUIController>().updateText();
        }
        else
            return;
    }
    public void subStrength()
    {
        if (playerOne.knockdownChance > 0 && playerOne.knockdownChance > playerOne.knockdownChanceStatAfterLastFight)
        {
            playerOne.knockdownChance--;
            playerOne.expPointsNow++;
            GetComponent<playerStatsUIController>().updateText();
        }
        else
            return;
    }
}
