using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class fightStatisticsTestRunner
{
    // A Test behaves as an ordinary method
    [Test]
    [TestCase(1, 1, 1)]
    [TestCase(1, 1, 5)]
    [TestCase(3, 2, 4)]
    public void fightEndRound(int resultOne, int resultTwo, int resultThree)
    {
        //ARRANGE
        List<int> expectedResults = new List<int>();
        List<int> results = new List<int>();
        expectedResults.Add(resultOne);
        expectedResults.Add(resultTwo);
        expectedResults.Add(resultThree);

        //ACT
        results = fightStatistics.fightEndedRound(resultOne, results);
        results = fightStatistics.fightEndedRound(resultTwo, results);
        results = fightStatistics.fightEndedRound(resultThree, results);

        CollectionAssert.AreEqual(expectedResults, results);
    }


    // A Test behaves as an ordinary method
    [Test]
    [TestCase("W", "W", "W")]
    [TestCase("W", "L", "W")]
    [TestCase("D", "L", "W")]

    public void compareList(string resultOne, string resultTwo, string resultThree)
    {

        //ARRANGE
        List<string> expectedResults = new List<string>();
        List<string> results = new List<string>();
        expectedResults.Add(resultOne);
        expectedResults.Add(resultTwo);
        expectedResults.Add(resultThree);

        //ACT
        results = fightStatistics.addResult(resultOne, results);
        results = fightStatistics.addResult(resultTwo, results);
        results = fightStatistics.addResult(resultThree, results);

        CollectionAssert.AreEqual(expectedResults, results);
    }

    // A Test behaves as an ordinary method
    [Test]
    [TestCase("KO", "KO", "KO")]
    [TestCase("Decision", "Decision", "Decision")]
    [TestCase("Decision", "KO", "Decision")]
    public void compareHowFightEnded(string resultOne, string resultTwo, string resultThree)
    {
        //ARRANGE
        List<string> expectedResults = new List<string> ();
        List<string> results = new List<string>();
        expectedResults.Add(resultOne);
        expectedResults.Add(resultTwo);
        expectedResults.Add(resultThree);

        //ACT
        results = fightStatistics.addHowTheFightEnded(resultOne, results);
        results = fightStatistics.addHowTheFightEnded(resultTwo, results);
        results = fightStatistics.addHowTheFightEnded(resultThree, results);

        //ASSERT
        CollectionAssert.AreEqual(expectedResults, results);
    }

        /*
        // A Test behaves as an ordinary method
        [Test]
        public void addVictory()
        {
            //ARRANGE
            List<string> expectedResults = new List<string> { "W" };
            List<string> results = new List<string>();

            //ACT
            results = fightStatistics.addResult("W", results);

            //ASSERT
            CollectionAssert.AreEqual(expectedResults, results);
        }

        // A Test behaves as an ordinary method
        [Test]
        public void addLose()
        {
            //ARRANGE
            List<string> expectedResults = new List<string> { "L" };
            List<string> results = new List<string>();

            //ACT
            results = fightStatistics.addResult("L", results);

            //ASSERT
            CollectionAssert.AreEqual(expectedResults, results);
        }

        // A Test behaves as an ordinary method
        [Test]
        public void addDraw()
        {
            //ARRANGE
            List<string> expectedResults = new List<string> { "D" };
            List<string> results = new List<string>();

            //ACT
            results = fightStatistics.addResult("D", results);

            //ASSERT
            CollectionAssert.AreEqual(expectedResults, results);
        }
        */
    }

