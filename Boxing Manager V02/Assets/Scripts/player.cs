using UnityEngine;

public class player : MonoBehaviour
{
    public int staminaInt; //ENDAST F�R FELS�KNING
    public int headHealthInt; //ENDAST F�R FELS�KNING

    public string name;
    public fighterState fighterStateNow;
    public fightStyle fightStyleNow;
    public fightStyleSO FightStyleSONow;
    public fightStatsShared FightStatsShared;
    public staminaManager StaminaManager;

    public GameObject playerPanel;
    public GameObject fightStatsGO;

    public bool Opponent; //Om det �r en motst�ndare eller egna spelaren
    public int expPointsNow;

    //StartV�rden
    public int expPointsStart; //Antal po�ng att dela ut vid start
    public int playerLvl;
    public int playerLvlHealthHead;
    public int playerLvlHealthBody;
    public int playerLvlHealthStamina;
    public int playerLvlHealthStaminaRecovery;

    [Header("Health")]
    public int bodyHealthStart;
    public int bodyHealthStatAfterLastFight;//Stat efter senaste matchen, g�r ej att g� l�gre �n detta.
    public int headHealthStart;
    public int headHealthAfterLastFight;//Stat efter senaste matchen, g�r ej att g� l�gre �n detta.
    public int staminaHealthStart;
    public int staminaHealthAfterLastFight;//Stat efter senaste matchen, g�r ej att g� l�gre �n detta.
    public int staminaRecoveryBetweenRounds;
    public int staminaRecoveryBetweenRoundsAfterLastFight;//Stat efter senaste matchen, g�r ej att g� l�gre �n detta.

    
    [Header("Defence")]
    public int guardHead;
    public int guardHeadStatAfterLastFight;//Stat efter senaste matchen, g�r ej att g� l�gre �n detta.
    public int guardBody;
    public int guardBodyStatAfterLastFight;//Stat efter senaste matchen, g�r ej att g� l�gre �n detta.
    public int guardFlexibleDuringFight;
    public int guardFlexibleDuringFightAfterLastFight; //Stat efter senaste matchen, g�r ej att g� l�gre �n detta.
    

    [Header("Attack Base")]
    public int accuracy; //Chans att tr�ffa
    public int accuracyStatAfterLastFight; //Stat efter senaste matchen, g�r ej att g� l�gre �n detta.
    public int strength; //Skada
    public int strengthStatAfterLastFight; //Stat efter senaste matchen, g�r ej att g� l�gre �n detta.
    public int endurance; //Stamina use

   [Header("Special Stats")]
    public int knockdownChance; //H�gre v�rde = st�rre chans att knocka motst�ndaren
    public int knockdownChanceStatAfterLastFight; //H�gre v�rde = st�rre chans att knocka motst�ndaren
    public int reduceOpponentStaminaRecoveryChance; //H�gre v�rde = st�rre chans att lyckas
    public int reduceOpponentStaminaRecoveryChanceStatAfterLastFight; //H�gre v�rde = st�rre chans att lyckas

    public int measureJabLimit; //Gr�nsen f�r antal aktioner innan positiva egenskaper b�rjar g�lla  
    public int measureJabPotentialIncreaseAccuracy;//�kade stat OM/N�R den �r aktiva

    public int jabKeepDistanceLvl;
    public bool jabKeepDistanceActive;
    public int jabKeepDistanceStatBoost;//Hur mycket motst�ndarens Accuracy minskar

   [Header("Attack Head")]
    public int jabAccuracyHead;
    public int jabStaminaUseHead;
    public int jabDamageHead;

    public int jabStaminaUseLow; //Relativt "vanlig" jab
    public int jabDamageLow; //Relativt "vanlig" jab

    public int crossAccuracyHead;
    public int crossStaminaUseHead;
    public int crossDamageHead;
    public int crossKnockDownHead;

    //ATTACK BODY
    [Header("Attack Body")]
    public int jabAccuracyBody;
    public int jabStaminaUseBody;
    public int jabDamageBody;
    public int jabStaminaDamageBody;

    public int crossAccuracyBody;
    public int crossStaminaUseBody;
    public int crossDamageBody;
    public int crossStaminaDamageBody;
    public int crossStaminaRecoveryDamageBody;

    [Header("During fight")]
    public int bodyHealthNow;
    public int headHealthNow;
    public int staminaHealthNow;
    public int knockdownCounter;
    public int damageTakenDuringRound;
     
    //Statistik under match
    public int actionsPerformed;
    public int actionsSucceded;
    public int actionsFailed;

    public int measureJabSuccededDurigFight; //Antalet lyckade under matchen. SKA NOLLST�LLAS

    //Stamina Manager
    public int staminaBoundriePassed; //Vilken niv� som spelaren p�verkas av "tr�tthet" aka Stamina.
    public int measureJabIncreaseAccuracyWhenActive; //Anv�nds vid ber�kning och �r 0 om den inte �r aktiverad �n.

    [Header("Skills known")]

    //Combos
    public bool oneTwoUnlocked;

    public void Awake()
    {
        playerPanel = GameObject.Find("===PLAYERPANEL===");

        jabStaminaUseLow = FightStatsShared.jabStaminaUseLow;
        jabDamageLow = Mathf.RoundToInt(strength / FightStatsShared.jabStaminaUseLow);

        accuracyStatAfterLastFight = accuracy;
        strengthStatAfterLastFight = strength;

        if (Opponent == true)
        {
            playerLvlHealthBody = playerLvl;
            playerLvlHealthHead = playerLvl;
            playerLvlHealthStamina = playerLvl;

            bodyHealthStart = playerPanel.GetComponent<attributeLevelManager>().bodyHealthByLvl[playerLvlHealthBody];
            headHealthStart = playerPanel.GetComponent<attributeLevelManager>().headHealthByLvl[playerLvlHealthHead];
            staminaHealthStart = playerPanel.GetComponent<attributeLevelManager>().staminaHealthByLvl[playerLvlHealthStamina];

            startFight();
        }
        

            bodyHealthNow = playerPanel.GetComponent<attributeLevelManager>().bodyHealthByLvl[playerLvlHealthBody];

            headHealthNow = playerPanel.GetComponent<attributeLevelManager>().headHealthByLvl[playerLvlHealthHead];

            staminaHealthNow = playerPanel.GetComponent<attributeLevelManager>().staminaHealthByLvl[playerLvlHealthStamina];

            staminaRecoveryBetweenRounds = playerPanel.GetComponent<attributeLevelManager>().staminaHealthRecoveryByLvl[playerLvlHealthStaminaRecovery];

            //Exp Points
            expPointsNow = expPointsStart;
        
    }

    public void startFight()
    {
        //H�lsa
        bodyHealthStart = playerPanel.GetComponent<attributeLevelManager>().bodyHealthByLvl[playerLvlHealthBody];
        headHealthStart = playerPanel.GetComponent<attributeLevelManager>().headHealthByLvl[playerLvlHealthHead];
        staminaHealthStart = playerPanel.GetComponent<attributeLevelManager>().staminaHealthByLvl[playerLvlHealthStamina];

        //Skada
        crossDamageHead = strength;
        crossDamageBody = strength;

        //Special
        crossKnockDownHead = knockdownChance;
        crossStaminaRecoveryDamageBody = reduceOpponentStaminaRecoveryChance;
        crossStaminaDamageBody = strength;
        jabStaminaDamageBody = Mathf.RoundToInt(strength / 2);
        jabKeepDistanceStatBoost = playerPanel.GetComponent<attributeLevelManager>().jabKeepDistanceLowerOpponentAccuracy[jabKeepDistanceLvl];


        //Accuracy
        jabAccuracyHead = accuracy;
        crossAccuracyHead = accuracy;
        jabAccuracyBody = accuracy;
        crossAccuracyBody = accuracy;

        //Strength
        if (strength - FightStatsShared.jabCrossDiffDamage <= 0)
        {
            jabDamageHead = 1;
        }
        else
            jabDamageHead = strength - FightStatsShared.jabCrossDiffDamage;

        if (strength - FightStatsShared.jabCrossDiffDamage <= 0)
        {
            jabDamageBody = 1;
        }
        else
            jabDamageBody = strength - FightStatsShared.jabCrossDiffDamage;

        jabDamageLow = Mathf.RoundToInt(strength / 4);

        //crossDamageHead = strength;
        //crossDamageBody = strength;

        //Stamina use
        if (endurance - FightStatsShared.jabLowerStaminaUse <= 0)
            jabStaminaUseHead = 1;
        else
            jabStaminaUseHead = endurance - FightStatsShared.jabLowerStaminaUse;

        if (endurance - FightStatsShared.jabLowerStaminaUse <= 0)
            jabStaminaUseBody = 1;
        else
            jabStaminaUseBody = endurance - FightStatsShared.jabLowerStaminaUse;

        crossStaminaUseHead = endurance;
        crossStaminaUseBody = endurance;
    }

    public void fighterStateUpdate(bool knockdown)
    {
        if (knockdown == true)
        {
            fighterStateNow = fighterState.Knockdown;

        }
    }

    public void staminaRecoveryMinValue()
    {
        if (staminaRecoveryBetweenRounds < 0)
        {
            staminaRecoveryBetweenRounds = 0;
        }
    }

    public void updateBodyHealth(int healthComsumed)
    {
        bodyHealthNow = bodyHealthUpdate.updateBodyHealth(bodyHealthNow, healthComsumed);
        damageTakenDuringRound += healthComsumed;

        if (bodyHealthNow <= 0)
        {
            fighterStateUpdate(true);
            bodyHealthNow = bodyHealthStart / 2;
            GetComponent<fightStatsKnockdownCause>().lowBodyHealth();
        }
    }

    public void updateStamina(int staminaChange)
    {
        staminaInt++;
        //Debug.Log(name + " Stamina: " + staminaHealthNow);
        //Debug.Log(name + " Antal Stamina Update: " + staminaInt);
        staminaHealthNow = staminaUpdate.updateStamina(staminaHealthNow, staminaChange);

        if (staminaHealthNow <= 0)
        {
            fighterStateUpdate(true); //Spelaren blir knockad
            staminaHealthNow = staminaHealthStart / 2;
            GetComponent<fightStatsKnockdownCause>().lowStamina();
        }

    }

    public void updateHeadHealth(int healthComsumed)
    {
        headHealthInt++;

        headHealthNow = headHealthUpdate.updateHeadHealth(headHealthNow, healthComsumed);
        damageTakenDuringRound += healthComsumed;

        //Debug.Log(name + ": " + headHealthNow);

        if (headHealthNow <= 0)
        {
            //Debug.Log("updateHeadHealth Zero");
            //Debug.Log("headHealthStart " + headHealthStart);
            fighterStateUpdate(true);
            headHealthNow = headHealthStart / 2;
            GetComponent<fightStatsKnockdownCause>().lowHeadHealth();

            /*if (Opponent == true)
            fightStatsGO.GetComponent<fightStatsKnockdownCause>().lowHeadHealth(false);
            else
            {
                fightStatsGO.GetComponent<fightStatsKnockdownCause>().lowHeadHealth(true);
            }
            */
        }
    }

    public void upgradePlayer()
    {
        bodyHealthNow = playerPanel.GetComponent<attributeLevelManager>().bodyHealthByLvl[playerLvlHealthBody];
        headHealthNow = playerPanel.GetComponent<attributeLevelManager>().headHealthByLvl[playerLvlHealthHead];
        staminaHealthNow = playerPanel.GetComponent<attributeLevelManager>().staminaHealthByLvl[playerLvlHealthStamina];
        staminaRecoveryBetweenRounds = playerPanel.GetComponent<attributeLevelManager>().staminaHealthRecoveryByLvl[playerLvlHealthStaminaRecovery];

        //crossDamageHead = strength;
        //crossDamageBody = strength;
    }

    public void resetAfterFight()
    {
       
        //Debug.Log("Stamina Recovery: " + staminaRecoveryBetweenRounds);
        headHealthNow = playerPanel.GetComponent<attributeLevelManager>().headHealthByLvl[playerLvlHealthHead];
        bodyHealthNow = playerPanel.GetComponent<attributeLevelManager>().bodyHealthByLvl[playerLvlHealthBody];
        staminaHealthNow = playerPanel.GetComponent<attributeLevelManager>().staminaHealthByLvl[playerLvlHealthStamina];
        staminaRecoveryBetweenRounds = playerPanel.GetComponent<attributeLevelManager>().staminaHealthRecoveryByLvl[playerLvlHealthStaminaRecovery];
        knockdownCounter = 0;
        actionsPerformed = 0;
        damageTakenDuringRound = 0;

        measureJabIncreaseAccuracyWhenActive = 0;
        measureJabSuccededDurigFight = 0;

        //Statistik
        
        actionsPerformed = 0;
        actionsSucceded = 0;
        actionsFailed = 0;
        
    }

    public void fightStatisticsNumberOfActions()
    {
        actionsPerformed++;

    }

    public void fightStatisticsNumberOfSuccededActions()
    {
        actionsSucceded++;
    }

    public void fightStatisticsNumberOfFailedActions()
    {
        actionsFailed++;
    }

    //Hur spelaren p�verkas av Stamina
    public void staminaEffect()
    {
        //Debug.Log("Stamina Effect");
        //Nollst�llning
        staminaBoundriePassed = 0;
        accuracy = accuracyStatAfterLastFight;
        strength = strengthStatAfterLastFight;

        //Kontrollerar vilken niv� spelaren ligger p�.
        for (int i = 0; StaminaManager.staminaBoundriesEffect.Length > i; i++)
        {

            if ((Mathf.Round(staminaHealthNow * 100 / staminaHealthStart)) < StaminaManager.staminaBoundriesEffect[i])
            {
                staminaBoundriePassed++;
            }
        }
        //Debug.Log("Stamina Gr�ns: " + StaminaManager.reduceAccuracy[staminaBoundriePassed]);
        //Debug.Log("Minska Accuracy: " + Mathf.Round(accuracy * StaminaManager.reduceAccuracy[staminaBoundriePassed] / 100));

        //P�verkar Accuracy
        accuracy = Mathf.RoundToInt(Mathf.Round(accuracy - accuracy * StaminaManager.reduceAccuracy[staminaBoundriePassed] / 100));
        //Vid sm� tal ska man �nd� p�verkas t.ex om minskningen blir 0,5 �r det i formeln ovanf�r = 0
        if (staminaBoundriePassed > 0 && accuracy == accuracyStatAfterLastFight)
        {
            accuracy--;
        }

        //Accuracy
        jabAccuracyHead = accuracy;
        crossAccuracyHead = accuracy;
        jabAccuracyBody = accuracy;
        crossAccuracyBody = accuracy;

        //P�verkar Strength
        strength = Mathf.RoundToInt(Mathf.Round(strength - strength * StaminaManager.reduceStrength[staminaBoundriePassed] / 100));

        //Vid sm� tal ska man �nd� p�verkas t.ex om minskningen blir 0,5 �r det i formeln ovanf�r = 0
        if (staminaBoundriePassed > 0 && strength == strengthStatAfterLastFight)
        {
            strength--;
        }

        crossDamageHead = strength;
        crossDamageBody = strength;

        if (strength - FightStatsShared.jabCrossDiffDamage <= 0)
        {
            jabDamageHead = 1;
        }
        else
            jabDamageHead = strength - FightStatsShared.jabCrossDiffDamage;

        if (strength - FightStatsShared.jabCrossDiffDamage <= 0)
        {
            jabDamageBody = 1;
        }
        else
            jabDamageBody = strength - FightStatsShared.jabCrossDiffDamage;

        jabDamageLow = Mathf.RoundToInt(strength / 4);

        //Debug.Log(name + (" Accuracy: " + accuracy));
        //Debug.Log(name + (" Strength: " + strength));
    }
}


 
