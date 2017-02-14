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