using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTestRunner : MonoBehaviour
{
    public string name;
    //public fighterState fighterStateNow;
    //public fightStyle fightStyleNow;

    //Diff mellan Jab och Cross
    public int jabLowerStaminaUse; //Lägre stamina use jämfört med Cross
    public int jabCrossDiffDamage; //Skillnad mellan damage mellan Cross och Jab

    //HEALTH
    public int bodyHealthStart;
    public int headHealthStart;
    public int staminaHealthStart;
    public int staminaRecoveryBetweenRounds;

    //DEFENCE
    public int guardHead;
    public int guardBody;

    //ATTACK
    public int accuracy; //Chans att träffa
    public int strength; //Skada
    public int endurance; //Stamina use

    //ATTACK HEAD
    public int jabAccuracyHead;
    public int jabStaminaUseHead;
    public int jabDamageHead;

    public int crossAccuracyHead;
    public int crossStaminaUseHead;
    public int crossDamageHead;
    public int crossKnockDownHead;

    //ATTACK BODY
    public int jabAccuracyBody;
    public int jabStaminaUseBody;
    public int jabDamageBody;
    public int jabStaminaDamageBody;

    public int crossAccuracyBody;
    public int crossStaminaUseBody;
    public int crossDamageBody;
    public int crossStaminaDamageBody;
    public int crossStaminaRecoveryDamageBody;



    //Värdering som ändras
    public int bodyHealthNow;
    public int headHealthNow;
    public int staminaHealthNow;

    public int knockdownCounter;
    public int damageTakenDuringRound;

    public void Start()
    {
        bodyHealthNow = bodyHealthStart;
        headHealthNow = headHealthStart;
        staminaHealthNow = staminaHealthStart;

        //Accuracy
        jabAccuracyHead = accuracy;
        crossAccuracyHead = accuracy;
        jabAccuracyBody = accuracy;
        crossAccuracyBody = accuracy;

        //Strength
        jabDamageHead = strength - jabCrossDiffDamage;
        jabDamageBody = strength - jabCrossDiffDamage;
        crossDamageHead = strength;
        crossDamageBody = strength;

        //Endurance
        jabStaminaUseHead = endurance - jabLowerStaminaUse;
        crossStaminaUseHead = endurance;
        jabStaminaUseBody = endurance - jabLowerStaminaUse;
        crossStaminaUseBody = endurance;
    }

   
}
