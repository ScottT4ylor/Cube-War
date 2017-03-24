using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassLookup : MonoBehaviour {

    //This class contains the lookup info for all of the different unit classes.
    //
    //Note: The hardcoded values are only here for testing, these will need to be modified when
    //we come up With the real numbers for all the units.
    //

    public static UnitClass unitClassLookup = new UnitClass();
    public static className cName;
    public static classType type;
    public static float attack;
    public static float defense;
    public static int cost;


    public static UnitClass unitLookup(string n)
    {
        switch (n)
        {
            case "attacker":
                cName = className.className1;
                type =
                    classType.classType1;
                attack = 2;
                defense = 1;
                cost = 50;
                unitClassLookup.unitSetup(cName, type, attack, defense, StateMachine.currentTurn(), cost);
                return unitClassLookup;
            case "defender":
                cName = className.className2;
                type = classType.classType2;
                attack = 1;
                defense = 2;
                cost = 25;
                unitClassLookup.unitSetup(cName, type, attack, defense, StateMachine.currentTurn(), cost);
                return unitClassLookup;
            default:
                return null;
        }
    }
}
