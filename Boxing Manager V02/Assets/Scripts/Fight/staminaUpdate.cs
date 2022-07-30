using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class staminaUpdate : MonoBehaviour
{
    
    public static int updateStamina(int staminaBefore, int staminaChange)
    {
    if (staminaBefore - staminaChange <= 0)
        {
            return 0;
        }

        return staminaBefore - staminaChange;

    }

    /*public void updateStamina(player Player, int staminaUse)
    {
        Player.staminaHealthNow -= staminaUse;

        if (Player.staminaHealthNow <= 0)
        {
            Player.fighterStateUpdate(true);
            Player.staminaHealthNow = Player.staminaHealthStart;
        }

    }*/
}
