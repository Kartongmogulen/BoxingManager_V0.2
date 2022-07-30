using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createOpponent : MonoBehaviour
{
    //Skapar motståndare utifrån lvl
    //Slumpar sedan fram vilka attribut där poängen ska delas ut

    public playerList PlayerList;
    public attributeLevelManager AttributeLevelManager;

    public int lvlOpponent;

    //Opponents values
    public int bodyHealth;
    public int headHealth;
    public int staminaHealth;
    public int staminaRecoveryBetweenRounds;

    public int maxLvlPerAttribute;


    public int randomInt;

    private void Start()
    {
        AttributeLevelManager = PlayerList.GetComponent<attributeLevelManager>();
        randomizePoints(lvlOpponent);
        //bodyHealth = AttributeLevelManager.bodyHealth[0];
    }

    public void randomizePoints(int lvlOpponent)
    {
    
        if (lvlOpponent> maxLvlPerAttribute)
        randomInt = Random.Range(0, maxLvlPerAttribute);
        else
        randomInt = Random.Range(0, lvlOpponent);

        bodyHealth = AttributeLevelManager.bodyHealthByLvl[randomInt];
    }
}
    



