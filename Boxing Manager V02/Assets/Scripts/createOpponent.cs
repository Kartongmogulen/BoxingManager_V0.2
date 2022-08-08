using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createOpponent : MonoBehaviour
{
    //Skapar motståndare utifrån lvl
    //Slumpar sedan fram vilka attribut där poängen ska delas ut

    public playerList PlayerList;
    public attributeLevelManager AttributeLevelManager;
    public player Player;
    public fightStyleSO FightStyleSO;
    public createOpponentAttributeList CreateOpponentAttributeList;

    public int lvlOpponent;

    public int fightStyleValue;

    public int randomInt;

    private void Start()
    {

        Player = GetComponent<player>();
        //AttributeLevelManager = PlayerList.GetComponent<attributeLevelManager>();
        createOpponentFunction();
        
        //randomizePoints(lvlOpponent);
        //bodyHealth = AttributeLevelManager.bodyHealth[0];
        //setLvl();
    }

    public void setLvl(int setLvlInt)
    {
        GetComponent<player>().playerLvl = setLvlInt;
        lvlOpponent = setLvlInt;
    }

    public void createOpponentFunction()
    {
        fightStyle();
        
        GetComponent<player>().Opponent = true;
        
        accuracyAndStrength(CreateOpponentAttributeList.accuracyAndStrengthPointsToShare[lvlOpponent]);
        bodySnatcherAndKO(CreateOpponentAttributeList.bodysnatcherAndKOPointsToShareMin[lvlOpponent], CreateOpponentAttributeList.bodysnatcherAndKOPointsToShareMax[lvlOpponent]);
        guardPoints(CreateOpponentAttributeList.guardPointsToShare[lvlOpponent]);
        guardFlexiblePoints(CreateOpponentAttributeList.guardFlexibleMin[lvlOpponent], CreateOpponentAttributeList.guardFlexiblePointsToShare[lvlOpponent]);
        combinations();
        GetComponent<player>().Awake();
        //Debug.Log("CreateOpponent");
    }

    public void fightStyle()
    {
        fightStyleValue = Random.Range(1, System.Enum.GetValues(typeof(fightStyle)).Length);
        //Debug.Log(GetComponent<player>().name + " " + fightStyleValue);
        GetComponent<player>().fightStyleNow = (global::fightStyle)fightStyleValue;
     
    }

    public void accuracyAndStrength(int pointsToShare)
    {
        //Debug.Log("Poäng att dela på: " + pointsToShare);
        
        //Accuracy tilldelning
        randomInt = Random.Range(0, pointsToShare);
        //Debug.Log("RandomInt: " + randomInt);
        Player.accuracy = CreateOpponentAttributeList.accuracyMin + randomInt;

        //Strength tilldelning
        randomInt = pointsToShare-randomInt;
        //Debug.Log("RandomInt: " + randomInt);
        Player.strength = CreateOpponentAttributeList.strengthMin + randomInt;
    }

    public void bodySnatcherAndKO(int min, int max)
    {

        randomInt = Random.Range(min, max);
        //Debug.Log("RandomInt: " + randomInt);

        Player.knockdownChance = randomInt;

        if (randomInt == max)
        {
            //Debug.Log("KO max: " + randomInt);
            Player.reduceOpponentStaminaRecoveryChance = min;
        }
        else
        {
            randomInt = Random.Range(min, max-randomInt);
            Player.reduceOpponentStaminaRecoveryChance = randomInt;
            //Debug.Log("RandomInt: " + randomInt);
        }

    }

    public void guardPoints(int pointsToShare)
    {
        randomInt = Random.Range(0, pointsToShare);
        Player.guardHead = CreateOpponentAttributeList.guardMin[lvlOpponent] + randomInt;

        //Återstående poäng tilldelas här
        randomInt = pointsToShare - randomInt;
        Player.guardBody = CreateOpponentAttributeList.guardMin[lvlOpponent] + randomInt;
    }

    public void guardFlexiblePoints(int min, int max)
    {
        randomInt = Random.Range(min, max);
        Player.guardFlexibleDuringFight = randomInt;
    }

    public void combinations()
    {
        //OneTwo-Combo
        randomInt = Random.Range(0, 100);
        if (randomInt <= CreateOpponentAttributeList.oneTwoComboProb[lvlOpponent])
        {
            Player.oneTwoUnlocked = true;
        }
    }

    /*
    public void randomizePoints(int lvlOpponent)
    {
    
        if (lvlOpponent> maxLvlPerAttribute)
        randomInt = Random.Range(0, maxLvlPerAttribute);
        else
        randomInt = Random.Range(0, lvlOpponent);

        bodyHealth = AttributeLevelManager.bodyHealthByLvl[randomInt];
    }
    */
}
    



