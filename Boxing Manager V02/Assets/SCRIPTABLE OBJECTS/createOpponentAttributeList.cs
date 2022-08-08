using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "createOpponentAttributeListSO", menuName = "ScriptableObject/createOpponentAttributeListSO")]
public class createOpponentAttributeList : ScriptableObject
{
    public int[] accuracyAndStrengthPointsToShare;
    public int accuracyMin;
    public int strengthMin;

    public int[] bodysnatcherAndKOPointsToShareMin;
    public int[] bodysnatcherAndKOPointsToShareMax;

    public int[] guardPointsToShare;
    public int[] guardMin;

    public int[] guardFlexiblePointsToShare;
    public int[] guardFlexibleMin;

    public int[] oneTwoComboProb;
}
