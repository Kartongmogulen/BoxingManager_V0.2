using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossFight : MonoBehaviour
{
    int randomPlayerOne;
    int randomPlayerTwo;
    bool crossHitOrNot;

    public bool cross(player attacker, player defender, bool head)
    {
        //Will the jab hit
        if (head == true)
        {
            randomPlayerOne = Random.Range(0, attacker.crossAccuracyHead);
            randomPlayerTwo = Random.Range(0, defender.guardHead);
        }

        else
        {
            randomPlayerOne = Random.Range(0, attacker.crossAccuracyBody);
            randomPlayerTwo = Random.Range(0, defender.guardBody);
        }

        if (randomPlayerOne > randomPlayerTwo)
        {
            crossHitOrNot = true;
        }
        else
            crossHitOrNot = false;

        return crossHitOrNot;
    }
}
