using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodySnatcherUpgrade : MonoBehaviour
{
    public player playerOne;

    public void add()
    {
        if (playerOne.expPointsNow > 0)
        {
            playerOne.reduceOpponentStaminaRecoveryChance++;
            playerOne.expPointsNow--;
            GetComponent<playerStatsUIController>().updateText();
        }
        else
            return;
    }

    public void sub()
    {
        if (playerOne.reduceOpponentStaminaRecoveryChance > 0 && playerOne.reduceOpponentStaminaRecoveryChance > playerOne.reduceOpponentStaminaRecoveryChanceStatAfterLastFight)
        {
            playerOne.reduceOpponentStaminaRecoveryChance--;
            playerOne.expPointsNow++;
            GetComponent<playerStatsUIController>().updateText();
        }
        else
            return;
    }
}
