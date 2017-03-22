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


    public static UnitClass unitLookup(string name)
    {
        switch (name)
        {
            case "attacker":
                unitClassLookup.unitSetup(className.className1, classType.classType1, 2, 1, StateMachine.currentTurn(), 50);
                return unitClassLookup;
            case "defender":
                unitClassLookup.unitSetup(className.className2, classType.classType2, 1, 2, StateMachine.currentTurn(), 25);
                return unitClassLookup;
            default:
                return null;
        }
    }
}
