using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponentAI : MonoBehaviour
{
    //Styr motst�ndarens beteende

    public fightManager FightManager;
    public player Opponent;
    public int guardAreaExtraLimit; //Gr�ns d� motst�ndaren b�rjar skydda ett omr�de mer

    private void Start()
    {
        FightManager = GetComponent<fightManager>();
    }

    public void getOpponentStart()
    {
        Opponent = FightManager.PlayerTwo;
    }

    //Kontrollerar om gr�ns f�r att skydda sig extra aktiveras
    public void defenceGuardPoints()
    {
        //Kontrollera om n�got omr�de �r under gr�nsen f�r extra guard

        //Debug.Log("Gr�ns Skydd: " + guardAreaExtraLimit * Opponent.headHealthStart / 100);

        if (Opponent.headHealthNow <= guardAreaExtraLimit * Opponent.headHealthStart/100)
        {
            //Debug.Log("Skydda Huvud");
            Opponent.guardHead = Opponent.guardHeadStatAfterLastFight + Opponent.guardFlexibleDuringFight;
            //Mindre skydd Kropp
            Opponent.guardBody = Opponent.guardBodyStatAfterLastFight - Opponent.guardFlexibleDuringFight;
        }

        if (Opponent.bodyHealthNow<= guardAreaExtraLimit * Opponent.bodyHealthStart / 100)
        {
            Debug.Log("Skydda Kropp");
            Opponent.guardBody = Opponent.guardBodyStatAfterLastFight + Opponent.guardFlexibleDuringFight;
            //Mindre skydd Huvud
            Opponent.guardHead = Opponent.guardHeadStatAfterLastFight - Opponent.guardFlexibleDuringFight;
        }

        if (Opponent.headHealthNow <= guardAreaExtraLimit * Opponent.headHealthStart / 100 && Opponent.bodyHealthNow <= guardAreaExtraLimit * Opponent.bodyHealthStart / 100)
        {
            Debug.Log("B�da delarna lika utsatta");
            Opponent.guardBody = Opponent.guardBodyStatAfterLastFight;
            Opponent.guardHead = Opponent.guardHeadStatAfterLastFight;
        }
    }
}
