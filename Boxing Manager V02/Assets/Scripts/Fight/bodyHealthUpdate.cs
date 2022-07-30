using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyHealthUpdate : MonoBehaviour
{
    public static int updateBodyHealth(int bodyHealthBefore, int healthComsumed)
    {
        if (bodyHealthBefore - healthComsumed <= 0)
        {
            return 0;
        }

        return bodyHealthBefore - healthComsumed;

    }
}
