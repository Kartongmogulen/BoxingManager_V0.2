using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "staminaManager", menuName = "ScriptableObject/StaminaManager")]

public class staminaManager : ScriptableObject
{
    public int[] staminaBoundriesEffect; //Gr�nsen n�r spelaren p�verkas
    public int[] reduceStrength;
    public int[] reduceAccuracy;
    //public int[] reduceGuardHead;
    //public int[] reduceGuardBody;
}
