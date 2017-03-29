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
    public static ClassLookup classinfo;
    public className cName;
    public classType type;
    public float attack;
    public float defense;
    public int cost;
    public Texture texture;
    public List<className> texKey;
    public List<Texture> texVal;
    public Dictionary<className, Texture> textures = new Dictionary<className, Texture>();


    public void Awake()
    {
        classinfo = this;
        if (texKey.Count == texVal.Count)
        {
            for (int i = 0; i < texKey.Count; i++)
            {
                textures.Add(texKey[i], texVal[i]);
            }
        }
    }


    public UnitClass Lookup(string n, UnitClass unitLookup)
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

    public static ClassLookup getClassLookup()
    {
        return classinfo;
    }
}
