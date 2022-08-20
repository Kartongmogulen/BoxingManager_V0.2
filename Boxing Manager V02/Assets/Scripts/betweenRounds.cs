using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class betweenRounds : MonoBehaviour
{
    public player PlayerOne;
    public player PlayerTwo;

    public int newStaminaValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void recoverStats(player PlayerTwo)
    {
        //Debug.Log("Between Rounds Scripts");
        newStaminaValue = PlayerOne.staminaHealthNow + PlayerOne.staminaRecoveryBetweenRounds;
        if (newStaminaValue > PlayerOne.staminaHealthStart)
        {
            PlayerOne.staminaHealthNow = PlayerOne.staminaHealthStart;
        }
        else
            PlayerOne.staminaHealthNow = newStaminaValue;

        newStaminaValue = PlayerTwo.staminaHealthNow + PlayerTwo.staminaRecoveryBetweenRounds;
        if (newStaminaValue > PlayerTwo.staminaHealthStart)
        {
            PlayerTwo.staminaHealthNow = PlayerTwo.staminaHealthStart;
        }
        else
            PlayerTwo.staminaHealthNow = newStaminaValue;
    }
}
