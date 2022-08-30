using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mouseOverButtonInfo : MonoBehaviour
{
    public player PlayerOne;
    public player PlayerTwo;

    public int playerTwoAccuracyStatModifier;//Om "KeepDistance" är true. Minska egna spelaren accuracy

    public GameObject fightScriptGO;

    public Text buttonJabHeadText;
    public Text buttonJabBodyText;

    public Text buttonCrossHeadText;
    public Text buttonCrossBodyText;

    public Text actionDescritionText;
    public Text damageText;
    public Text staminaDamageText;
    public Text staminaUsePlayerText;
    public Text accuracyStatText;
    public Text guardStatText;

    //public TextMeshProUGUI accuracyStatText;

    public void colorStatIfAffected()
    {

        if (playerTwoAccuracyStatModifier - PlayerOne.measureJabIncreaseAccuracyWhenActive > 0)
        {
            //Debug.Log("MouseOverJab Mod != 0");
            accuracyStatText.color = new Color(1, 0, 0, 1);

        }

        else if (playerTwoAccuracyStatModifier - PlayerOne.measureJabIncreaseAccuracyWhenActive < 0)
        {
            //Debug.Log("MouseOverJab Mod != 0");
            accuracyStatText.color = new Color(0, 0.5f, 0, 1);

        }

        else
        {
            //Debug.Log("MouseOverJab Mod = 0");
            accuracyStatText.color = new Color(0, 0, 0, 1);

        }
    }


    public void mouseOverJabHead()
    {
        getPlayerTwo();
        actionDescritionText.text = buttonJabHeadText.text;
        damageText.text = "Damage: " + PlayerOne.jabDamageHead;
        staminaDamageText.text = "Stamina damage: " + 0;
        staminaUsePlayerText.text = "Stamina use: " + PlayerOne.jabStaminaUseHead;
        accuracyStatText.text = "Accuracy: " + (PlayerOne.jabAccuracyHead + PlayerOne.measureJabIncreaseAccuracyWhenActive - playerTwoAccuracyStatModifier);
        guardStatText.text = "Guard (def): " + PlayerTwo.guardHead;

        colorStatIfAffected();
    }

    public void mouseOverJabMeasure()
    {
        getPlayerTwo();
        actionDescritionText.text = buttonJabHeadText.text;
        damageText.text = "Damage: " + PlayerOne.jabDamageLow;
        staminaDamageText.text = "Stamina damage: " + 0;
        staminaUsePlayerText.text = "Stamina use: " + PlayerOne.jabStaminaUseLow;
        accuracyStatText.text = "Accuracy: " + (PlayerOne.jabAccuracyHead + PlayerOne.measureJabIncreaseAccuracyWhenActive - playerTwoAccuracyStatModifier);
        guardStatText.text = "Guard (def): " + PlayerTwo.guardHead;
        colorStatIfAffected();
    }

    public void mouseOverKeepDistance()
    {
        getPlayerTwo();
        actionDescritionText.text = buttonJabHeadText.text;
        damageText.text = "Damage: " + PlayerOne.jabDamageLow;
        staminaDamageText.text = "Stamina damage: " + 0;
        staminaUsePlayerText.text = "Stamina use: " + PlayerOne.jabStaminaUseHead;
        accuracyStatText.text = "Accuracy: " + (PlayerOne.jabAccuracyHead + PlayerOne.measureJabIncreaseAccuracyWhenActive - playerTwoAccuracyStatModifier);
        guardStatText.text = "Guard (def): " + PlayerTwo.guardHead;
        colorStatIfAffected();
    }

    public void mouseOverJabBody()
    {
        getPlayerTwo();
        actionDescritionText.text = buttonJabBodyText.text;
        damageText.text = "Damage: " + PlayerOne.jabDamageBody;
        staminaDamageText.text = "Stamina damage: " + PlayerOne.jabStaminaDamageBody;
        staminaUsePlayerText.text = "Stamina use: " + PlayerOne.jabStaminaUseBody;
        accuracyStatText.text = "Accuracy: " + PlayerOne.jabAccuracyBody;
        guardStatText.text = "Guard (def): " + PlayerTwo.guardBody;
        colorStatIfAffected();
    }

    public void mouseOverCrossHead()
    {
        getPlayerTwo();
        actionDescritionText.text = buttonCrossHeadText.text;
        damageText.text = "Damage: " + PlayerOne.crossDamageHead;
        staminaDamageText.text = "Stamina damage: " + 0;
        staminaUsePlayerText.text = "Stamina use: " + PlayerOne.crossStaminaUseHead;
        accuracyStatText.text = "Accuracy: " + (PlayerOne.jabAccuracyHead + PlayerOne.measureJabIncreaseAccuracyWhenActive - playerTwoAccuracyStatModifier); ;
        guardStatText.text = "Guard (def): " + PlayerTwo.guardHead;

        colorStatIfAffected();
    }

    public void mouseOverCrossBody()
    {
        getPlayerTwo();
        actionDescritionText.text = buttonCrossBodyText.text;
        damageText.text = "Damage: " + PlayerOne.crossDamageBody;
        staminaDamageText.text = "Stamina damage: " + PlayerOne.crossStaminaDamageBody;
        staminaUsePlayerText.text = "Stamina use: " + PlayerOne.crossStaminaUseBody;
        accuracyStatText.text = "Accuracy: " + PlayerOne.crossAccuracyBody;
        guardStatText.text = "Guard (def): " + PlayerTwo.guardBody;

        colorStatIfAffected();
    }

    public void OnMouseExit()
    {
    
        actionDescritionText.text = "";
        damageText.text = "Damage: ";
        staminaDamageText.text = "Stamina damage: ";
        staminaUsePlayerText.text = "Stamina use: ";
        accuracyStatText.text = "Accuracy: ";
        guardStatText.text = "Guard (def): ";
    }

    public void getPlayerTwo()
    {
      
        PlayerTwo = fightScriptGO.GetComponent<fightManager>().PlayerTwo;

        if (PlayerTwo.jabKeepDistanceActive == true)
            playerTwoAccuracyStatModifier = PlayerTwo.jabKeepDistanceStatBoost;
        else
            playerTwoAccuracyStatModifier = 0;
    }
}
