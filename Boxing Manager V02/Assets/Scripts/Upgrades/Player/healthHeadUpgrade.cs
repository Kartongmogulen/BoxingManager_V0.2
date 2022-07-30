using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthHeadUpgrade : MonoBehaviour
{
    public player playerOne;
    public attributeLevelManager AttributeLevelManager;

    private void Start()
    {
        AttributeLevelManager = GetComponent<attributeLevelManager>();
    }

    public void add()
    {
        if (playerOne.expPointsNow > 0 && playerOne.playerLvlHealthHead < AttributeLevelManager.headHealthByLvl.Count - 1)
        {
            
            playerOne.playerLvlHealthHead++;
            playerOne.expPointsNow--;
            playerOne.upgradePlayer();
            GetComponent<playerStatsUIController>().updateText();
            
        }
        else
            return;
    }

    public void sub()
    {
        if (playerOne.playerLvlHealthHead > 0 && playerOne.headHealthNow > playerOne.headHealthAfterLastFight)
        {
           playerOne.playerLvlHealthHead--;
            playerOne.expPointsNow++;
            playerOne.upgradePlayer();
            GetComponent<playerStatsUIController>().updateText();
        }
        else
            return;
    }
}
