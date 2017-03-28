using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum className
{
    className1,
    className2,
    className3
}

public enum classType
{
    classType1,
    classType2,
    classType3
}

public class ClassLookup : MonoBehaviour {

    //This class contains the lookup info for all of the different unit classes.
    //
    //Note: The hardcoded values are only here for testing, these will need to be modified when
    //we come up With the real numbers for all the units.
    //
    [SerializeField]
    public static className cName;
    public static classType type;
    public static float attack;
    public static float defense;
    public static int cost;
    public static Texture texture;
    public static Dictionary<className, Texture> textures = new Dictionary<className, Texture>();

    public static UnitClass Lookup(string n, UnitClass unitLookup)
    {
        switch (n)
        {
            case "attacker":
                cName = className.className1;
                type = classType.classType1;
                attack = 2;
                defense = 1;
                cost = 50;
                texture = textures[cName];
                unitLookup.unitSetup(cName, type, attack, defense, StateMachine.currentTurn(), cost, texture);
                return unitLookup;
            case "defender":
                cName = className.className2;
                type = classType.classType2;
                attack = 1;
                defense = 2;
                cost = 25;
                texture = textures[cName];
                unitLookup.unitSetup(cName, type, attack, defense, StateMachine.currentTurn(), cost, texture);
                return unitLookup;
            default:
                return null;
        }
    }
}
