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


public class UnitClass : MonoBehaviour
{

    public className uC;
    public classType uT;
    public float att;
    public float def;
    public int owningPlayer;
    public int pointCost;


    public void unitSetup(className cn, classType ct, float a, float d, int pl, int p)
    {
        uC = cn;
        uT = ct;
        att = a;
        def = d;
        owningPlayer = pl;
        pointCost = p;
    }

    public void unitSetup(UnitClass copy)
    {
        uC = copy.unitClass;
        uT = copy.unitType;
        att = copy.attack;
        def = copy.defense;
        owningPlayer = copy.owner;
        pointCost = copy.cost;
    }

    public className unitClass
    {
        get
        {
            return uC;
        }
        set
        {
            uC = value;
        }
    }

    public classType unitType
    {
        get
        {
            return uT;
        }
        set
        {
            uT = value;
        }
    }

    public float attack
    {
        get
        {
            return att;
        }
        set
        {
            att = value;
        }
    }

    public float defense
    {
        get
        {
            return def;
        }
        set
        {
            def = value;
        }
    }

    public int owner
    {
        get
        {
            return owningPlayer;
        }
        set
        {
            owningPlayer = value;
        }
    }

    public int cost
    {
        get
        {
            return pointCost;
        }
        set
        {
            pointCost = value;
        }
    }

    public void startAttack()
    {
        //do stuff for attack
    }

    public void startDefense()
    {
        //do stuff for defense
    }


    //To Do: Add unit cost variable&property

}