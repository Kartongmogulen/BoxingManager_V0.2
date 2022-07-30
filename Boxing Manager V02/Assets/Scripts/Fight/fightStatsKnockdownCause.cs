using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightStatsKnockdownCause : MonoBehaviour
{
    //Hanterar statistik orsaken till att spelare blev nerslagen

    public List<string> knockDownCausePlayerOne;
    public List<string> knockDownCausePlayerTwo;

    //Skapar lista för nya matchen
    public void specialAttackCrossKO(bool PlayerOne, string playerName)
    {
        if (PlayerOne == true)
        knockDownCausePlayerOne.Add("KO");
        else
            knockDownCausePlayerTwo.Add("KO");

    }

    
}
