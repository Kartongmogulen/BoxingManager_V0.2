using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simulateFight : MonoBehaviour
{
    //Script för att simulera match mellan två spelare. Används för balansering

    public player PlayerOne;
    public player PlayerTwo;

    public GameObject fightScriptsGO;

    public bool simulationON;


    // Start is called before the first frame update
    void Start()
    {
        if (simulationON == true)
        {
            fightScriptsGO.GetComponent<fightManager>().simulation = true;
            fightScriptsGO.GetComponent<fightManager>().PlayerOne = PlayerOne;
            fightScriptsGO.GetComponent<fightManager>().PlayerTwo = PlayerTwo;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
