using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockdown : MonoBehaviour
{
    //Styr om en spelare hamnar i Knockdown-state
    public int extraGuardForKnockdown; //Extra guard så inte endast Accuarcy avgör

    public int attackerRandomNumb;
    public int defenderRandomNumb;

    bool knockdownOrNot;
    
    public int timePlayerGetsUp;

    public bool willPlayerGetKnockdown(player attacker, player defender, bool head)
    {
        attackerRandomNumb = 0;
        defenderRandomNumb = 0;

        //Debug.Log("Attack Knockdown Potential: " + attacker.crossKnockDownHead);
        if (head == true)
        {
            attackerRandomNumb = Random.Range(0, attacker.crossKnockDownHead+1);
            
            defenderRandomNumb = Random.Range(0, defender.guardHead + extraGuardForKnockdown);
            //Debug.Log("Defender Knockdown Roll: " + defenderRandomNumb);

            //Debug.Log("Attack Knockdown Roll: " + attackerRandomNumb + " VS Defender Knockdown Roll: " + defenderRandomNumb);

            if (attackerRandomNumb > defenderRandomNumb)
            {
                knockdownOrNot = true;
            }

            else
            {
                knockdownOrNot = false;
            }
        }
        //Debug.Log("knockdown state " + knockdownOrNot);
  
        return knockdownOrNot;
    }

    public void willPlayerGetUp(player defender, bool knockdownCountSkip)
    {
        //Debug.Log("Will player get up");
        if (defender.knockdownCounter < GetComponent<fightManager>().totalKnockdownCountBeforeStop)
        {
            timePlayerGetsUp = Random.Range(3, 5);
            //Debug.Log("Time player get up: " + timePlayerGetsUp);
            GetComponent<knockdownClock>().startTimer(defender, knockdownCountSkip);
        }

        else
        {
            timePlayerGetsUp = 11;
            GetComponent<knockdownClock>().startTimer(defender, knockdownCountSkip);
        }
    }
}
