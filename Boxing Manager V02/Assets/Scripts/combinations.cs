using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combinations : MonoBehaviour
{
    public attributeManager AttributeManager;
    public int costOneTwoComboExtra; //Kostnaden ?ver standard 1 AP

    public void oneTwo_JabCrossPlayerOne() 
    {
        if (GetComponent<actionsLeftPlayer>().actionPointsNow >= costOneTwoComboExtra+1)
        {
            GetComponent<actionsLeftPlayer>().subActionPoints(costOneTwoComboExtra);
            GetComponent<fightManager>().playerOneJabHead(false);
            GetComponent<fightManager>().playerOneCrossHead(AttributeManager.oneTwoAccuracyIncrease[0]);
        }
    }

    public void oneTwo_JabCrossPlayerTwo()
    {
        Debug.Log("OneTwoPlayerTwo");
        GetComponent<fightManager>().playerTwoJabHeadCombo();
        GetComponent<fightManager>().playerTwoCrossHead(AttributeManager.oneTwoAccuracyIncrease[0]);
        GetComponent<fightManager>().afterActionChoicePlayerTwo(2);
        

    }
}
