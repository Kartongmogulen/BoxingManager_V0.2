using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class succedOrNotAction : MonoBehaviour
{
    int randomAttacker;
    int randomDefender;
    bool succedOrNot;
    bool jabKeepDistanceActive;

    public GameObject FightScriptsGO;

    public bool action(int attackerStat, int defenderStat, bool head)
    {

        //Debug.Log("Attacker accuracy: " + attackerStat);
        //Debug.Log("Defender Guard: " + defenderStat);
        //Will the action succed?


        if (head == true)
        {
            
        randomAttacker = Random.Range(1, attackerStat + 1);
        //Debug.Log("Attacker Roll: " + randomAttacker);
        randomDefender = Random.Range(1, defenderStat + 1);
        //Debug.Log("Defender Roll: " + randomDefender);
        //Debug.Log("Attack: " + randomAttacker + " VS Defender: " + randomDefender);
                    
        }

        else
        {
            //Debug.Log("succedOrNotAction Body");
            randomAttacker = Random.Range(1, attackerStat+1);
            randomDefender = Random.Range(1, defenderStat+1);
            //Debug.Log("Attack: " + randomAttacker + " VS Defender: " + randomDefender);
        }

        if (randomAttacker > randomDefender)
        {
            succedOrNot = true;
        }
        else
            succedOrNot = false;

        //Debug.Log("succedOrNotAction Body:" + succedOrNot);

        return succedOrNot;
    }

}
