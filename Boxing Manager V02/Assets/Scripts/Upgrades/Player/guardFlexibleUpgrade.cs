using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardFlexibleUpgrade : MonoBehaviour
{
    public player playerOne;
    public attributeManager AttributeManager;

    public void add()
    {
        if (playerOne.expPointsNow >= AttributeManager.costGuardFlexibleDuringFight)
        {
            playerOne.guardFlexibleDuringFight++;
            playerOne.expPointsNow -= AttributeManager.costGuardFlexibleDuringFight;
            GetComponent<playerStatsUIController>().updateText();
        }
        else
            return;
    }

    public void sub()
    {
        if (playerOne.guardFlexibleDuringFight > 0 && playerOne.guardFlexibleDuringFight > playerOne.guardFlexibleDuringFightAfterLastFight)
        {
            playerOne.guardFlexibleDuringFight--;
            playerOne.expPointsNow += AttributeManager.costGuardFlexibleDuringFight;
            GetComponent<playerStatsUIController>().updateText();
        }
        else
            return;
    }
}
