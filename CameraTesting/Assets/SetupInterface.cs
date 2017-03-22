using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupInterface : MonoBehaviour {
    public string targetClass = "attacker"; // This is what you will set to change what class you get from the button
    public GameObject cubePrefab;
    public GameObject newUnit;
    public GameDriver driver = GameDriver.getGameDriverRef();
    
	public void instantiateNewUnit()
    {
        if (!StateMachine.isPlacingCube)
        {
            newUnit = Instantiate(cubePrefab) as GameObject;
            newUnit.GetComponent<UnitClass>().unitSetup(ClassLookup.unitLookup(targetClass));
            driver.placingCube(newUnit);
        }
    }

    public void instantiateNewUnit(string target)      //An overload in case the interface calls it this way
    {
        if (!StateMachine.isPlacingCube)
        {
            newUnit = Instantiate(cubePrefab) as GameObject;
            newUnit.GetComponent<UnitClass>().unitSetup(ClassLookup.unitLookup(target));
            driver.placingCube(newUnit);
        }
    }
}
