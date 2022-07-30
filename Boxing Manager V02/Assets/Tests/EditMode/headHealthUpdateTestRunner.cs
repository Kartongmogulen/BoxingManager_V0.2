using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class headHealthUpdateTestRunner
{
    // A Test behaves as an ordinary method
    [Test]
    public void reduceByOne()
    {
        int headHéalthAfter = headHealthUpdate.updateHeadHealth(20, 1);

        Assert.AreEqual(19, headHéalthAfter);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void reduceByFive()
    {
        int headHéalthAfter = headHealthUpdate.updateHeadHealth(20, 5);

        Assert.AreEqual(15, headHéalthAfter);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void ifNegativeSetToZero()
    {
        int headHéalthAfter = headHealthUpdate.updateHeadHealth(1, 5);

        Assert.AreEqual(0, headHéalthAfter);

    }

}
