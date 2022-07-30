using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightStatsKnockdownCause : MonoBehaviour
{
    //Hanterar statistik orsaken till att spelare blev nerslagen

    public List<string> knockDownCause;

    public List<string> knockDownCausePlayerOne;
    public List<string> knockDownCausePlayerTwo;

    //Skapar lista för nya matchen
    public void specialAttackCrossKO()
    {
        Debug.Log("Special Attack Cross KO");
        knockDownCause.Add("KO");
    }

    public void lowHeadHealth()
    {
        knockDownCause.Add("Head health low");
    }

    public void lowBodyHealth()
    {
        knockDownCause.Add("Body health low");
    }

    public void lowStamina()
    {
        knockDownCause.Add("Stamina low");
    }
}
