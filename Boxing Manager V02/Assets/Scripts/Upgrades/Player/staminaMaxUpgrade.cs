using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staminaMaxUpgrade : MonoBehaviour
{
    public player playerOne;
    public attributeLevelManager AttributeLevelManager;

    private void Start()
    {
        AttributeLevelManager = GetComponent<attributeLevelManager>();
    }

    public void add()
    {
        if (playerOne.expPointsNow > 0 && playerOne.playerLvlHealthStamina < AttributeLevelManager.staminaHealthByLvl.Count - 1)
        {
            playerOne.playerLvlHealthStamina++;
            playerOne.expPointsNow--;
            playerOne.upgradePlayer();
            GetComponent<playerStatsUIController>().updateText();

        }
        else
            return;
    }

    public void sub()
    {
        if (playerOne.playerLvlHealthStamina > 0 && playerOne.playerLvlHealthStamina > playerOne.staminaHealthAfterLastFight)
        {
            playerOne.playerLvlHealthStamina--;
            playerOne.expPointsNow++;
            playerOne.upgradePlayer();
            GetComponent<playerStatsUIController>().updateText();
        }
        else
            return;
    }
}
