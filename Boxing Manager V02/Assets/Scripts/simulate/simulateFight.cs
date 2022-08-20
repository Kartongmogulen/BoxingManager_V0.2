using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class simulateFight : MonoBehaviour
{
    //Script för att simulera match mellan två spelare. Används för balansering


    public player PlayerOne;
    public player PlayerTwo;

    public fightManager FightManager;
    public GameObject fightScriptsGO;

    public float waitSecInt;
    public int randomInt;

    public bool simulationON;
    public bool continueSimLoop; //True om simulering ska fortsätta.
    //public bool playerOneAndTwoFullTurnSimCheck; //Vid simulering när Spelare Ett och Två får genomföra sin omgång och sedan paus

    public int actionPointsStart;
    

    public int i;
    public int playerOneActions;
    public int playerTwoActions;
    public bool roundEnded;
    public bool fightEnded;
    //public int fightIndex;//Vilken match i ordningen.

    public TextMeshProUGUI commentatorText;

    public TextMeshProUGUI playerOneHealthHeadText;
    public TextMeshProUGUI playerOneHealthBodyText;
    public TextMeshProUGUI playerOneHealthStaminaText;
    public TextMeshProUGUI playerOneActionPerformedText;

    public TextMeshProUGUI playerTwoHealthHeadText;
    public TextMeshProUGUI playerTwoHealthBodyText;
    public TextMeshProUGUI playerTwoHealthStaminaText;
    public TextMeshProUGUI playerTwoActionPerformedText;

    [Header("PlayerOneFightStatistics")]
    public List<int> actionPerformedPlayerOne;

    [Header("PlayerTwoFightStatistics")]
    public List<int> actionPerformedPlayerTwo;

    [Header("PlayerOneAction")]
    public bool onlyJabHead;
    public bool onlyCrossHead;
    public bool headAttacks;
    public bool onlyJabBody;
    public bool onlyCrossBody;
    public bool bodyAttacks;
    public int numberOfPossibleAttacks;

    // Start is called before the first frame update
    public void Start()
   {
        FightManager = fightScriptsGO.GetComponent<fightManager>();

        if (simulationON == true)
        {
            FightManager.simulation = true;
            FightManager.PlayerOne = PlayerOne;
            FightManager.PlayerTwo = PlayerTwo;
        }

        if (headAttacks == true)
        {
            onlyJabHead = false;
            onlyCrossHead = false;
            numberOfPossibleAttacks += 2;
        }

        if (bodyAttacks == true)
        {
            onlyJabBody = false;
            onlyCrossBody = false;
            numberOfPossibleAttacks += 2;
        }

        

        //Nollställer data
        resetDataBeforeFight();
    }

    IEnumerator waitSec()
    {

        if (fightEnded == false)
        {
            for (int i = 0; i < FightManager.roundActionsPerRound + 1; i++)
            {
                yield return new WaitForSeconds(waitSecInt);
                //simHalfRound();
                simOneAction();
                //Debug.Log("Round Ended: " + roundEnded);

                if (PlayerTwo.fighterStateNow == fighterState.Knockdown)
                {
                    FightManager.startCheckIfNextRoundCanStart();
                    yield return new WaitForSeconds(waitSecInt);
                }


            }
        }

        
        
               
    }

    public void simOneAction()
    {
        Debug.Log("SimOneAction");
        //if (roundEnded == false)
        playerOneAction();
        
    }

    //Simulerar alla aktioner/runda (EJ rond)
    public void simPlayerOneAndTwoTurn()
    {
        
        Debug.Log("simAllActionsPlayerOneAndTwo");
        if (roundEnded == false)
        {
            for (int i = 0; i < actionPointsStart; i++)
            {
                simOneAction();
            }
        }
    }

    public void simHalfRound()
    {
        if (roundEnded == true)
        {
            //roundEnded = false;
            //i = 0;
            resetDataAfterRound();
        }

        for (int i = 0; i < 2; i++)
        {
            Debug.Log("Rond slut: " + roundEnded);
            if (roundEnded == false)
            {
                simPlayerOneAndTwoTurn();
            }
        }

        
    }

    public void simOneRound()
    {
        simHalfRound();
        for (int i = 0; i < 1; i++)
        {
           
            Debug.Log("SimHalfRound");
            StartCoroutine(waitSec());
        }
    }



    //Nollställer data
    public void resetDataBeforeFight()
    {
        PlayerOne.startFight();
        FightManager.GetComponent<opponentAI>().Opponent = PlayerTwo;
        setUpFight();
        
    }

    public void resetDataAfterRound()
    {
        playerTwoActions = 0;
        i = 0;
        roundEnded = false;
        Debug.Log("resetDataAfterRound");
    }

    public void startSimulation()
    {
        resetDataBeforeFight();
        //PlayerOne.startFight();
        //PlayerTwo.startFight();
        //FightManager.GetComponent<opponentAI>().Opponent = PlayerTwo;
        //setUpFight();
        continueSimLoop = true;
        startFight();
       
        //playerOneAction();
    }

    //Before Fight
    public void setUpFight()
    {
        FightManager.playerOnesTurn = true;
        FightManager.endOfFight = false;

        //PlayerOne.resetAfterFight();
        //PlayerTwo.resetAfterFight();


        //actionPointsLeftStart();
        fightScriptsGO.GetComponent<roundManager>().resetRoundAfterFight();
        //playerOneAction();

        FightManager.GetComponent<scorecardManager>().resetAfterFight();

    }

    //During fight
    public void startFight()
    {
        if (continueSimLoop == true)
        StartCoroutine(waitSec());
    }
   
    //Player One
    public void playerOneAction()
    {
        //Debug.Log("Round ended: " + roundEnded);
        
        if (FightManager.playerOnesTurn == true && i < FightManager.roundActionsPerRound)
        {
            
            if (headAttacks == true && bodyAttacks == true && FightManager.playerOnesTurn == true)
            {
                randomInt = Random.Range(0, 100);
                Debug.Log("Random Int: " + randomInt);

                if (randomInt < 100 / numberOfPossibleAttacks)
                {
                    jabHead();
                }
                else if (randomInt < (100 / numberOfPossibleAttacks) * 2)
                {
                    crossHead();
                }

                else if (randomInt < (100 / numberOfPossibleAttacks) * 3)
                {
                    jabBody();
                }

                else if (randomInt < (100 / numberOfPossibleAttacks) * 4)
                {
                    crossBody();
                }

            }

           else if (onlyJabHead == true)
            {
                jabHead();
                
            }

            else if (onlyCrossHead == true)
            {
                crossHead();
                
            }

            else if (headAttacks == true && FightManager.playerOnesTurn == true)
            {
                randomInt = Random.Range(0, 100);
                Debug.Log("Val av attack RandomInt: " + randomInt);
                if (randomInt < 50)
                {
                    FightManager.playerOneJabHead(true);
                    //Debug.Log("Jab: " + i);
                    i++;
                    playerOneActions++;
                    fightScriptsGO.GetComponent<actionsLeftPlayer>().subActionPoints(1);
                    commentatorText.text = PlayerOne.name + " Jabs to the Head";
                }

                else
                {
                    FightManager.playerOneCrossHead(0);
                    i++;
                    Debug.Log("Cross: " + i);
                    playerOneActions++;
                    fightScriptsGO.GetComponent<actionsLeftPlayer>().subActionPoints(1);
                    commentatorText.text = PlayerOne.name + " Cross to the Head";
                }
                
            }

            else if (onlyJabBody == true)
            {
                jabBody();
            }

            else if (onlyCrossBody == true)
            {
                crossBody();
            }
        

            if (roundEnded == false)
            {
                PlayerOne.fightStatisticsNumberOfActions();
                fightScriptsGO.GetComponent<roundManager>().afterPlayerAction();
            }
            
        }
        //else if (FightManager.playerOnesTurn == false && roundEnded == false && playerTwoActions < 6)
        else if (FightManager.playerOnesTurn == false && playerTwoActions < FightManager.roundActionsPerRound)
        {
            playerTwoActions++;
            FightManager.fightUpdate();
            //Debug.Log("playerOneAction");
        }

        /*if (playerTwoActions == FightManager.roundActionsPerRound)
        {
            //FightManager.fightUpdate();
            resetDataAfterRound();

        }
        */

        if (roundEnded == true)
        {
            resetDataAfterRound();
        }
       
             
        updateStatText();
        
    }

    public void jabHead()
    {
        FightManager.playerOneJabHead(true);
        i++;
        playerOneActions++;
        fightScriptsGO.GetComponent<actionsLeftPlayer>().subActionPoints(1);
        commentatorText.text = PlayerOne.name + " jabs to the head";
    }

    public void crossHead()
    {
        FightManager.playerOneCrossHead(0);
        i++;
        playerOneActions++;
        fightScriptsGO.GetComponent<actionsLeftPlayer>().subActionPoints(1);
        commentatorText.text = PlayerOne.name + " Cross to the Head";
    }

    public void jabBody()
    {
        FightManager.playerOneJabBody(true);
        i++;
        playerOneActions++;
        fightScriptsGO.GetComponent<actionsLeftPlayer>().subActionPoints(1);
        commentatorText.text = PlayerOne.name + " Jabs to the Body";
    }

    public void crossBody()
    {
        FightManager.playerOneCrossBody(0);
        i++;
        playerOneActions++;
        fightScriptsGO.GetComponent<actionsLeftPlayer>().subActionPoints(1);
        commentatorText.text = PlayerOne.name + " Cross to the Body";
    }

    public void updateStatText()
    {
        playerOneActionPerformedText.text = "Actions performed: " + PlayerOne.actionsPerformed;
        playerOneHealthHeadText.text = "Head: " + PlayerOne.headHealthNow;
        playerOneHealthBodyText.text = "Body: " + PlayerOne.bodyHealthNow;
        playerOneHealthStaminaText.text = "Stamina: " + PlayerOne.staminaHealthNow;

        playerTwoActionPerformedText.text = "Actions performed: " + PlayerTwo.actionsPerformed;
        playerTwoHealthHeadText.text = "Head: " + PlayerTwo.headHealthNow;
        playerTwoHealthBodyText.text = "Body: " + PlayerTwo.bodyHealthNow;
        playerTwoHealthStaminaText.text = "Stamina: " + PlayerTwo.staminaHealthNow;
    }
   

    public void endOfFight()
    {

        //Spara Data
        actionPerformedPlayerOne.Add(PlayerOne.actionsPerformed);

        actionPerformedPlayerTwo.Add(PlayerTwo.actionsPerformed);

        Debug.Log("Fight slut");
        fightEnded = true;
        return;
    }
    
}
