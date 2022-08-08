using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "fightStyleSO", menuName = "ScriptableObject/fightStyleSO")]
public class fightStyleSO : ScriptableObject
{
    //public fightStyle FightStyle;

    public enum fightStyle
    {
        None,
        Headhunter,
        BodySnatcher
    }

    public void Awake()
    {
        
    }
}
