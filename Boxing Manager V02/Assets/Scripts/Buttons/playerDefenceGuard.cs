using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDefenceGuard : MonoBehaviour
{
    public player PlayerOne;
    public GameObject playerPanelGO;
    public playerStatsUIController PlayerStatsUIController;
    public bool guardHeadActive;
    public bool guardBodyActive;

    private void Start()
    {
        PlayerStatsUIController = playerPanelGO.GetComponent<playerStatsUIController>();
        PlayerStatsUIController.guardDuringFight();
    }

    public void addGuardPointHead()
    {
        if (guardHeadActive == true)
        {
            return;
        }
        guardHeadActive = true;
        guardBodyActive = false;
        PlayerOne.guardHead = PlayerOne.guardHeadStatAfterLastFight + PlayerOne.guardFlexibleDuringFight;
        PlayerOne.guardBody = PlayerOne.guardBodyStatAfterLastFight - PlayerOne.guardFlexibleDuringFight;
        PlayerStatsUIController.guardDuringFight();

    }

    public void subGuardPointHead()
    {
        if (guardHeadActive == false)
        {
            return;
        }
        guardHeadActive = false;
        PlayerOne.guardHead = PlayerOne.guardHeadStatAfterLastFight;
        PlayerOne.guardBody = PlayerOne.guardBodyStatAfterLastFight;
        PlayerStatsUIController.guardDuringFight();
    }

    public void addGuardPointBody()
    {
        if (guardBodyActive == true)
        {
            return;
        }
        guardBodyActive = true;
        guardHeadActive = false;
        PlayerOne.guardHead = PlayerOne.guardHeadStatAfterLastFight - PlayerOne.guardFlexibleDuringFight;
        PlayerOne.guardBody = PlayerOne.guardBodyStatAfterLastFight + PlayerOne.guardFlexibleDuringFight;

        //PlayerOne.guardBody += PlayerOne.guardFlexibleDuringFight;
        //PlayerOne.guardHead -= PlayerOne.guardFlexibleDuringFight;
        PlayerStatsUIController.guardDuringFight();

    }

    public void subGuardPointBody()
    {
        if (guardBodyActive == false)
        {
            return;
        }
        guardBodyActive = false;
        PlayerOne.guardHead = PlayerOne.guardHeadStatAfterLastFight;
        PlayerOne.guardBody = PlayerOne.guardBodyStatAfterLastFight;
        PlayerStatsUIController.guardDuringFight();
    }

    //-----------------------------
    //Opponent
    public void opponentGuardHead()
    {

    }
}
