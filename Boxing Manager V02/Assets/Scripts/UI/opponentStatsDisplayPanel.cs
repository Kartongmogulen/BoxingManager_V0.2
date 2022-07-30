using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class opponentStatsDisplayPanel : MonoBehaviour
{
    //Visar info om motståndaren i meny

    public GameObject fightScriptsGO;
    public player Opponent;

    public Text nameOpponentText;
    public Text accuracyText;
    public Text StrengthText;
    public Text knockDownText;
    public Text BodySnatcherText;
    public Text guardHeadText;
    public Text guardBodyText;
    public Text HealthHeadText;
    public Text HealthBodyText;
    public Text staminaHealthMaxText;
    public Text staminaRecoveryHealthText;

    private void Start()
    {
        Opponent = fightScriptsGO.GetComponent<fightManager>().opponentListGO.PlayerList[fightScriptsGO.GetComponent<fightManager>().opponentIndex];
        nameOpponentText.text = "Name: " + Opponent.name;
        accuracyText.text = "Accuracy: " + Opponent.accuracy;
        StrengthText.text = "Strength: " + Opponent.strength;
        knockDownText.text = "Knockdown: " + Opponent.knockdownChance;
        BodySnatcherText.text = "Bodysnatcher: " + Opponent.crossStaminaRecoveryDamageBody;
        guardHeadText.text = "Guard (Head): " + Opponent.guardHead;
        guardBodyText.text = "Guard (Body): " + Opponent.guardBody;
        HealthHeadText.text = "Health (Head): " + Opponent.headHealthStart;
        HealthBodyText.text = "Health (Body): " + Opponent.bodyHealthStart;
        staminaHealthMaxText.text = "Stamina, Max: " + Opponent.staminaHealthStart;
        staminaRecoveryHealthText.text = "Stamina, Recovery: " + Opponent.staminaRecoveryBetweenRounds;
    }

    public void updateOpponent()
    {
        Opponent = fightScriptsGO.GetComponent<fightManager>().opponentListGO.PlayerList[fightScriptsGO.GetComponent<fightManager>().opponentIndex];
        nameOpponentText.text = "Name: " + Opponent.name;
        accuracyText.text = "Accuracy: " + Opponent.accuracy;
        StrengthText.text = "Strength: " + Opponent.strength;
        knockDownText.text = "Knockdown: " + Opponent.knockdownChance;
        BodySnatcherText.text = "Bodysnatcher: " + Opponent.crossStaminaRecoveryDamageBody;
        guardHeadText.text = "Guard (Head): " + Opponent.guardHead;
        guardBodyText.text = "Guard (Body): " + Opponent.guardBody;
        HealthHeadText.text = "Health (Head): " + Opponent.headHealthStart;
        HealthBodyText.text = "Health (Body): " + Opponent.bodyHealthStart;
        staminaHealthMaxText.text = "Stamina, Max: " + Opponent.staminaHealthStart;
        staminaRecoveryHealthText.text = "Stamina, Recovery: " + Opponent.staminaRecoveryBetweenRounds;
    }
}
