using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headHealthUpdate : MonoBehaviour
{
    //public int headHealthNow;
    public static int updateHeadHealth(int headHealthBefore, int healthComsumed)
    {
        if (headHealthBefore - healthComsumed <= 0)
        {
            return 0;
        }
        //damageTakenDuringRound += healthComsumed;

        return headHealthBefore - healthComsumed;// damageTakenDuringRound;

        /*public void updateHeadHealth(player Player, int healthComsumed)
         {

             Player.headHealthNow -= healthComsumed;
             Player.damageTakenDuringRound += healthComsumed;

             if (Player.headHealthNow <= 0)
             {
                 Player.fighterStateUpdate(true);
                 Player.headHealthNow = Player.headHealthStart;
             }
         }*/
    }
}