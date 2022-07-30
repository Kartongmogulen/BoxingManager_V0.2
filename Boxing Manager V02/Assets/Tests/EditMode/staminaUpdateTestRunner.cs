using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class staminaUpdateTestRunner
{
    

    // A Test behaves as an ordinary method
    [Test]
    public void reduceByOne()
    {
        int staminaAfter = staminaUpdate.updateStamina(10,1);

        Assert.AreEqual(9, staminaAfter);
    }
    
    // A Test behaves as an ordinary method
    [Test]
    public void reduceByFive()
    {
        int staminaAfter = staminaUpdate.updateStamina(10, 5);

        Assert.AreEqual(5, staminaAfter);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void ifNegativeSetToZero()
    {
        int staminaAfter = staminaUpdate.updateStamina(1, 5);

        Assert.AreEqual(0, staminaAfter);
        
    }

}
