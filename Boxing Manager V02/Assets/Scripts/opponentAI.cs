using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponentAI : MonoBehaviour
{
    //Styr motståndarens beteende

    public fightManager FightManager;
    public player Opponent;
    public int guardAreaExtraLimit; //Gräns då motståndaren börjar skydda ett område mer

    private void Start()
    {
        FightManager = GetComponent<fightManager>();
    }

    public void getOpponentStart()
    {
        Opponent = FightManager.PlayerTwo;
    }

    //Kontrollerar om gräns för att skydda sig extra aktiveras
    public void defenceGuardPoints()
    {
        //Kontrollera om något område är under gränsen för extra guard

        //Debug.Log("Gräns Skydd: " + guardAreaExtraLimit * Opponent.headHealthStart / 100);

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
            Debug.Log("Båda delarna lika utsatta");
            Opponent.guardBody = Opponent.guardBodyStatAfterLastFight;
            Opponent.guardHead = Opponent.guardHeadStatAfterLastFight;
        }
    }
}
