using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerTwoActionDisplay : MonoBehaviour
{
    //Styr panelen som visar vilka attacker motståndaren genomfört. 

    public TextMeshProUGUI actionOneText;
    public TextMeshProUGUI actionTwoText;
    public TextMeshProUGUI actionThreeText;

    public int actionNumber;

    public TextMeshProUGUI jabHeadText;
    public TextMeshProUGUI crossHeadText;
    public TextMeshProUGUI jabBodyText;
    public TextMeshProUGUI crossBodyText;

    public int jabHeadAmount;
    public int crossHeadAmount;
    public int jabBodyAmount;
    public int crossBodyAmount;

    public void updateTextLastActionRound(string actionName, bool hitOrNot)
    {
        if (actionNumber == 0 && hitOrNot == true)
            actionOneText.text = "Action 1: " + actionName + " (Hit)";
        else if (actionNumber == 0 && hitOrNot == false)
            actionOneText.text = "Action 1: " + actionName + " (Miss)";

        if (actionNumber == 1 && hitOrNot == true)
            actionTwoText.text = "Action 2: " + actionName + " (Hit)";
        else if (actionNumber == 1 && hitOrNot == false)
            actionTwoText.text = "Action 2: " + actionName + " (Miss)";

        if (actionNumber == 2 && hitOrNot == true)
            actionThreeText.text = "Action 3: " + actionName + " (Hit)";
        else if (actionNumber == 2 && hitOrNot == false)
            actionThreeText.text = "Action 3: " + actionName + " (Miss)";

        if (actionNumber == 2)
            actionNumber = 0;
        else
            actionNumber++;
    }

    public void fightUpdateText(bool head, bool jab)
    {
        if (head == true && jab == true)
        {
            jabHeadAmount++;
            jabHeadText.text = "Jab head (count): " + jabHeadAmount;
        }

        else if (head == true && jab == false)
        {
            crossHeadAmount++;
            crossHeadText.text = "Cross head (count): " + crossHeadAmount;
        }

        else if (head == false && jab == true)
        {
           jabBodyAmount++;
           jabBodyText.text = "Jab body (count): " + jabBodyAmount;
        }
        
        else if (head == false && jab == false)
        {
            crossBodyAmount++;
            crossBodyText.text = "Cross body (count): " + crossBodyAmount;
        }

    }

    public void resetBetweenFight()
    {
        jabHeadAmount = 0;
        crossHeadAmount = 0;
        jabBodyAmount = 0;
        crossBodyAmount = 0;

        jabHeadText.text = "Jab head (count): " + jabHeadAmount;
        crossHeadText.text = "Cross head (count): " + crossHeadAmount;
        jabBodyText.text = "Jab body (count): " + jabBodyAmount;
        crossBodyText.text = "Cross body (count): " + crossBodyAmount;

        actionOneText.text = "Action 1: ";
        actionTwoText.text = "Action 2: ";
        actionThreeText.text = "Action 3: ";
    }

   
      
}
