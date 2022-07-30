using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class healthPanelTextUpdate : MonoBehaviour
{
    public GameObject FightScriptsGO;

    public fightManager FightManager;
    //Player One
    public TextMeshProUGUI nameTextPlayerOne;
    public TextMeshProUGUI HeadHealthTextPlayerOne;
    public TextMeshProUGUI BodyHealthTextPlayerOne;
    public TextMeshProUGUI StaminaHealthTextPlayerOne;
    public TextMeshProUGUI KnockdownCounterTextPlayerOne;

    //Opponent
    public TextMeshProUGUI nameTextPlayerTwo;
    public TextMeshProUGUI HeadHealthTextPlayerTwo;
    public TextMeshProUGUI BodyHealthTextPlayerTwo;
    public TextMeshProUGUI StaminaHealthTextPlayerTwo;
    public TextMeshProUGUI KnockdownCounterTextPlayerTwo;

    private void Start()
    {
        FightManager = FightScriptsGO.GetComponent<fightManager>();
    }

    public void updatePlayerOneText()
    {
        nameTextPlayerOne.text = "Name: " + FightManager.PlayerOne.name;
        HeadHealthTextPlayerOne.text = "Head: " + FightManager.PlayerOne.headHealthNow;
        BodyHealthTextPlayerOne.text = "Body: " + FightManager.PlayerOne.bodyHealthNow;
        StaminaHealthTextPlayerOne.text = "Stamina: " + FightManager.PlayerOne.staminaHealthNow;
        KnockdownCounterTextPlayerOne.text = "Knocked down: " + FightManager.PlayerOne.knockdownCounter + " times";
    }

    public void updateOpponentText()
    {
        nameTextPlayerTwo.text = "Name: " + FightManager.PlayerTwo.name;
        HeadHealthTextPlayerTwo.text = "Head: " + FightManager.PlayerTwo.headHealthNow;
        BodyHealthTextPlayerTwo.text = "Body: " + FightManager.PlayerTwo.bodyHealthNow;
        StaminaHealthTextPlayerTwo.text = "Stamina: " + FightManager.PlayerTwo.staminaHealthNow;
        KnockdownCounterTextPlayerTwo.text = "Knocked down: " + FightManager.PlayerTwo.knockdownCounter + " times";
    }
}
