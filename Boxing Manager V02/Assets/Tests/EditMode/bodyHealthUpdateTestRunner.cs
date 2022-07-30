using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class bodyHealthUpdateTestRunner
{
    // A Test behaves as an ordinary method
    [Test]
    public void reduceByOne()
    {
        int bodyHealthAfter = bodyHealthUpdate.updateBodyHealth(15, 1);

        Assert.AreEqual(14, bodyHealthAfter);
    }
    // A Test behaves as an ordinary method
    [Test]
    public void reduceByFive()
    {
        int bodyHealthAfter = bodyHealthUpdate.updateBodyHealth(15, 5);

        Assert.AreEqual(10, bodyHealthAfter);
    }
    
    // A Test behaves as an ordinary method
    [Test]
    public void ifNegativeSetToZero()
    {
        int bodyHealthAfter = bodyHealthUpdate.updateBodyHealth(1, 5);

        Assert.AreEqual(0, bodyHealthAfter);

    }
}
