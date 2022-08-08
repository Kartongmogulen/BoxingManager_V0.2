using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "attributeManager", menuName = "AttributeManager")]
public class attributeManager : ScriptableObject
{
    [Header("Guard")]
    public int costGuardFlexibleDuringFight;

    [Header("Combos")]
    public int[] oneTwoAccuracyIncrease;
    public int oneTwoCostUnlock;
}
