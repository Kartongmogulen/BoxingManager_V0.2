using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBodyUpgrade : MonoBehaviour
{
    public player playerOne;
    public attributeLevelManager AttributeLevelManager;

    private void Start()
    {
        AttributeLevelManager = GetComponent<attributeLevelManager>();
    }

    public void add()
    {
        if (playerOne.expPointsNow > 0 && playerOne.playerLvlHealthBody < AttributeLevelManager.bodyHealthByLvl.Count - 1)
        {
            playerOne.playerLvlHealthBody++;
            playerOne.expPointsNow--;
            playerOne.upgradePlayer();
            GetComponent<playerStatsUIController>().updateText();

        }
        else
            return;
    }
    public void sub()
    {
        if (playerOne.playerLvlHealthBody > 0 && playerOne.bodyHealthStart > playerOne.bodyHealthStatAfterLastFight)
        {
            playerOne.playerLvlHealthBody--;
            playerOne.expPointsNow++;
            playerOne.upgradePlayer();
            GetComponent<playerStatsUIController>().updateText();
        }
        else
            return;
    }

}
