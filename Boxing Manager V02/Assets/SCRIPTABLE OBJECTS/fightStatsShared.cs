using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "fightSharedStats" , menuName = "SharedFightStats")]
public class fightStatsShared : ScriptableObject
{
    public int jabStaminaUseLow;
    public int jabDamageLowModifier;

    //Diff mellan Jab och Cross
    public int jabLowerStaminaUse; //Lägre stamina use jämfört med Cross
    public int jabCrossDiffDamage; //Skillnad mellan damage mellan Cross och Jab
}
