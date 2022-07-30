using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staminaRecoveryUpgrade : MonoBehaviour
{
    public player playerOne;
    public attributeLevelManager AttributeLevelManager;

    private void Start()
    {
        AttributeLevelManager = GetComponent<attributeLevelManager>();
    }

    public void add()
    {
        if (playerOne.expPointsNow > 0 && playerOne.playerLvlHealthStaminaRecovery < AttributeLevelManager.staminaHealthRecoveryByLvl.Count - 1)
        {
            playerOne.playerLvlHealthStaminaRecovery++;
            playerOne.expPointsNow--;
            playerOne.upgradePlayer();
            GetComponent<playerStatsUIController>().updateText();

        }
        else
            return;
    }
    public void sub()
    {
        if (playerOne.playerLvlHealthStaminaRecovery > 0 && playerOne.staminaRecoveryBetweenRounds > playerOne.staminaRecoveryBetweenRoundsAfterLastFight)
        {
            playerOne.playerLvlHealthStaminaRecovery--;
            playerOne.expPointsNow++;
            playerOne.upgradePlayer();
            GetComponent<playerStatsUIController>().updateText();
        }
        else
            return;
    }

}
