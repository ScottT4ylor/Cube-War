using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupInterface : MonoBehaviour {
    public string targetClass = "attacker"; // This is what you will set to change what class you get from the button
    public UnitClass unitClass;
    public GameObject cubePrefab;
    public GameObject newUnit;
    public GameDriver driver = GameDriver.getGameDriverRef();


    public void instantiateNewUnit()
    {
        if (StateMachine.turnState != Turn.pause)
        {
            if (!StateMachine.isPlacingCube && driver.getPlayerPointsRemaining() < ClassLookup.Lookup(targetClass, unitClass).cost)
            {
                newUnit = Instantiate(cubePrefab) as GameObject;
                newUnit.GetComponent<UnitClass>().unitSetup(ClassLookup.Lookup(targetClass, unitClass));
                driver.placingCube(newUnit);
            }
        }
    }

    public void instantiateNewUnit(string target)      //An overload in case the interface calls it this way
    {
        if (StateMachine.turnState != Turn.pause)
        {
            if (!StateMachine.isPlacingCube && driver.getPlayerPointsRemaining() < ClassLookup.Lookup(targetClass, unitClass).cost)
            {
                newUnit = Instantiate(cubePrefab) as GameObject;
                newUnit.GetComponent<UnitClass>().unitSetup(ClassLookup.Lookup(target, unitClass));
                driver.placingCube(newUnit);
            }
        }
    }

    public void endPlayerSetup()
    {
        if (StateMachine.turnState != Turn.pause)
        {
            if (StateMachine.isPlacingCube == false)
            {
                if (StateMachine.currentTurn() == 1)
                {
                    StateMachine.endP1Setup();
                    StateMachine.passTurn();
                }
                else if (StateMachine.currentTurn() == 2)
                {
                    StateMachine.endP2Setup();
                    StateMachine.passTurn();
                }
            }
        }

    }
}
