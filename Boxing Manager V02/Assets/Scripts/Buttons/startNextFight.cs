using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startNextFight : MonoBehaviour
{
    /// <summary>
    /// Hanterar att starta nästa Fight
    /// </summary>

    public GameObject fightScriptGO;
    public GameObject FightUiGO;
    public player playerOne;

    public healthPanelTextUpdate HealthPanelTextUpdate;

    public GameObject playerPanelGO;
    public GameObject playerPanelScriptsGO;
    public GameObject fightPanelGO;
    public GameObject victoryPanelGO;

    private void Start()
    {
        HealthPanelTextUpdate = FightUiGO.GetComponent<healthPanelTextUpdate>();
    }

    public void playerPanelToFight()
    {
        playerPanelGO.SetActive(false);
        fightPanelGO.SetActive(true);

        fightScriptGO.GetComponent<fightManager>().setUpFight();
        HealthPanelTextUpdate.updatePlayerOneText();
        playerOne.startFight();
        saveStatsForPlayer();
    }

    //Sparar stats för spelaren så det ej går att få lägre vid nästa match än dessa poäng.
    //Ska inte gå att gå ner i lvl.
    public void saveStatsForPlayer()
    {
        playerOne.accuracyStatAfterLastFight = playerOne.accuracy;
        playerOne.strengthStatAfterLastFight = playerOne.strength;
        playerOne.knockdownChanceStatAfterLastFight = playerOne.knockdownChance;
        playerOne.reduceOpponentStaminaRecoveryChanceStatAfterLastFight = playerOne.reduceOpponentStaminaRecoveryChance;
        playerOne.guardHeadStatAfterLastFight = playerOne.guardHead;
        playerOne.guardBodyStatAfterLastFight = playerOne.guardBody;
        playerOne.headHealthAfterLastFight = playerOne.headHealthStart;
        playerOne.bodyHealthStatAfterLastFight = playerOne.bodyHealthStart;
        playerOne.staminaHealthAfterLastFight = playerOne.playerLvlHealthStamina;
        playerOne.staminaRecoveryBetweenRoundsAfterLastFight = playerOne.staminaRecoveryBetweenRounds;
    }
    public void victoryPanelToPlayerPanel()
    {
        victoryPanelGO.SetActive(false);
        playerPanelGO.SetActive(true);
        playerPanelScriptsGO.GetComponent<playerStatsUIController>().updateText();
    }


}
