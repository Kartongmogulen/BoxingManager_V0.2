using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTwoAction : MonoBehaviour
{
    //Avgör vad motståndaren kommer utföra för aktion
    public float randomNumb;
    int i;
    public int numberOfActionsAvailable;//Antal aktioner att välja på

    public GameObject UIScriptsGO;
    /// </summary>
    /// 

        public void headHunter()
    {
        //Debug.Log("Headhunter action");
        //randomNumb = 50;
        randomNumb = Random.Range(0, 100);
        //Debug.Log("Random nr: " + randomNumb);

        if (randomNumb <= 33)
        {
            GetComponent<fightManager>().playerTwoJabHead();
            //UIScriptsGO.GetComponent<playerTwoActionDisplay>().updateText(i, "Jab Head");
            //Debug.Log("Jab Head");
        }

        else if (randomNumb <= 66)
        {
            GetComponent<fightManager>().playerTwoCrossHead();
            //Debug.Log("Cross Head");
        }

        else if (randomNumb <= 83)
        {
            GetComponent<fightManager>().playerTwoCrossBody();
            //Debug.Log("Cross Body");
        }

        else
        {
            GetComponent<fightManager>().playerTwoJabBody();
            //Debug.Log("Jab Body");
        }

        
    }

    public void bodySnatcher()
    {
        //Debug.Log("Headhunter action");
        randomNumb = Random.Range(0, 100);
        //Debug.Log("Bodysnatcher Random nr: " + randomNumb);

        if (randomNumb <= 35)
        {
            GetComponent<fightManager>().playerTwoJabBody();
            //Debug.Log("Jab Body");
        }

        else if (randomNumb <= 70)
        {
            GetComponent<fightManager>().playerTwoCrossBody();
            //Debug.Log("Cross Body");
        }

        else if (randomNumb <= 85)
        {
            GetComponent<fightManager>().playerTwoCrossHead();
            //Debug.Log("Cross Head");
        }

        else
        {
            GetComponent<fightManager>().playerTwoJabHead();
            //Debug.Log("Jab Head");
        }
    }

    //Slumpar aktion
    public void randomized ()
    {
        randomNumb = Random.Range(0, 100);
        //randomNumb = 99;

        if (randomNumb <= 100 / numberOfActionsAvailable)
        {
            GetComponent<fightManager>().playerTwoCrossBody();
            Debug.Log("Cross Body" + i);
            i++;
        }
        
        if (randomNumb >= (100 / numberOfActionsAvailable) && randomNumb <= (100 / numberOfActionsAvailable)*2)
        {
            GetComponent<fightManager>().playerTwoJabHead();
            Debug.Log("Jab Body" + i);
            i++;
        }

        
        if (randomNumb >= (100 / numberOfActionsAvailable)*2 && randomNumb <= (100 / numberOfActionsAvailable)*3)
        {
            GetComponent<fightManager>().playerTwoJabBody();
            Debug.Log("Jab Body" + i);
            i++;
        }

        
         if (randomNumb >= (100 / numberOfActionsAvailable)*3 && randomNumb <= (100 / numberOfActionsAvailable)*4)
        {
            GetComponent<fightManager>().playerTwoCrossHead();
            Debug.Log("Cross Head" + i);
            i++;
        }
        

    }

    public void onlyJabMeasure()
    {
        //Debug.Log("PlayerTwo only JabMeasure");
        GetComponent<fightManager>().playerTwoJabHeadMeasure();
    }

    public void onlyJabKeepDistance()
    {
        Debug.Log("PlayerTwo only KeepDistance");
        GetComponent<fightManager>().playerTwoJabKeepDistance();
    }

    public void randomizedHead()
    {
        randomNumb = Random.Range(0, 100);
        //Debug.Log("RandomizedHead: " + randomNumb);

        if (randomNumb <= (100 / 2))
        {
            GetComponent<fightManager>().playerTwoJabHead();
        }

        else
            GetComponent<fightManager>().playerTwoCrossHead();

    }

    public void test()
    {
        if (i == 0)
            onlyJabKeepDistance();
        else
            jabHead();
        i++;

    }

        public void crossHead()
    {
        GetComponent<fightManager>().playerTwoCrossHead();
        i++;
    }

    public void jabHead()
    {
        GetComponent<fightManager>().playerTwoJabHead();
        i++;
    }

    public void jabBody()
    {
        GetComponent<fightManager>().playerTwoJabBody();
        i++;
    }

    public void crossBody()
    {
        GetComponent<fightManager>().playerTwoCrossBody();
        i++;
    }

}
