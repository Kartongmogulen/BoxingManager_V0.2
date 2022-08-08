using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoActionDescription : MonoBehaviour
{
    public TextMeshProUGUI actionHeaderText;
    public Text descriptionText;
    public Text statBoostText;
    public Text costUnlockText;

    public attributeManager AttributeManager;

    public void OneTwoCombo()
    {
        actionHeaderText.text = "One-Two Combo";
        descriptionText.text = "Jab followed by a Cross. Increase the chance to land the cross";
        statBoostText.text = "Increase Accuracy of the Cross by " + AttributeManager.oneTwoAccuracyIncrease[0] + " during the Combo";
        costUnlockText.text = "Cost to unlock: " + AttributeManager.oneTwoCostUnlock;
    }

    public void guardFlexiblePoints()
    {
        actionHeaderText.text = "Guard flexible during fight";
        descriptionText.text = "During the fight the fighter is able to guard a certain area more but leaving other parts more exposed";
        statBoostText.text = "Increase guard but leave other parts more exposed";
        costUnlockText.text = "Cost to unlock: " + AttributeManager.costGuardFlexibleDuringFight;
    }
}
