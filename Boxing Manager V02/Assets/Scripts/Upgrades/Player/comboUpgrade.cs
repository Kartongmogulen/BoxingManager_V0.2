using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboUpgrade : MonoBehaviour
{
    public player playerOne;
    public attributeManager AttributeManager;

    public void unlockCombo()
    {
        if (playerOne.oneTwoUnlocked == false  && playerOne.expPointsNow >= AttributeManager.oneTwoCostUnlock)
        {
            playerOne.oneTwoUnlocked = true;
            playerOne.expPointsNow -= AttributeManager.oneTwoCostUnlock;
            GetComponent<playerStatsUIController>().updateText();
        }
    }
}
