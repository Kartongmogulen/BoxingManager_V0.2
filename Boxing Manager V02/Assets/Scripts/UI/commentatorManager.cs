using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class commentatorManager : MonoBehaviour
{
    public int seconds;
    public int waitSecondsBeforeUpdatePlayer;
    public int waitSecondsBeforeUpdateOpponent;
    public int waitSecondsBeforeUpdateSpeedFlow; //Är ej beroende av någon av spelarna
    public TextMeshProUGUI commentatorText;

    public GameObject fightScriptsGO;

    public void startTimer(player Attacker, player Defender, bool head, bool jab, bool actionCompleted, bool specialAttack)
    {
        //Debug.Log("StartTimer: Name " + Attacker.name);
        seconds = 0;
        StartCoroutine(timer(Attacker, Defender, head, jab, actionCompleted, specialAttack));
    }

    IEnumerator timer(player Attacker, player Defender, bool head, bool jab, bool actionCompleted, bool specialAttack)
    {
        
        if (head == true && jab == true)
        commentatorText.text = Attacker.name + " jabs to the head";
        if (head == true && jab == false)
        commentatorText.text = Attacker.name + " throws a cross to the head";
        if (head == false && jab == true)
        commentatorText.text = Attacker.name + " jabs to the body";
        if(head == false && jab == false)
        commentatorText.text = Attacker.name + " throws a cross to the body";

        if (fightScriptsGO.GetComponent<fightManager>().playerOnesTurn == true)
        yield return new WaitForSeconds(waitSecondsBeforeUpdatePlayer);
        else
            yield return new WaitForSeconds(waitSecondsBeforeUpdateOpponent);

        //yield return new WaitForSeconds(waitSecondsBeforeUpdate);
        if (actionCompleted == true && specialAttack == false)
        {
            actionCompletedUpdate();
        }

       else if  (head == true && jab == false && actionCompleted == true && specialAttack == true)
        {
            knockDownUpdate(Defender);
            //yield return new WaitForSeconds(waitSecondsBeforeUpdate);
        }

        else if (head == false && jab == false && actionCompleted == true && specialAttack == true)
        {
            actionCompletedUpdate();
            //yield return new WaitForSeconds(waitSecondsBeforeUpdate);
            if (fightScriptsGO.GetComponent<fightManager>().playerOnesTurn == true)
                yield return new WaitForSeconds(waitSecondsBeforeUpdatePlayer);
            else
                yield return new WaitForSeconds(waitSecondsBeforeUpdateOpponent);
            crossBodySpecial(Defender);
            
        }

        else
            commentatorText.text = "MISS!";

    }

    public void actionCompletedUpdate()
    {
        commentatorText.text = "HIT!";
    }
    public void knockDownUpdate(player Defender)
    {
        commentatorText.text = Defender.name + " gets knockdowned!";        
    }

    public void crossBodySpecial(player Defender)
    {
        commentatorText.text = Defender.name + "´s body gets hurt!";
    }
}
