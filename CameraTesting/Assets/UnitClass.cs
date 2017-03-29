using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClass : MonoBehaviour
{

    public className uC;
    public classType uT;
    public float att;
    public float def;
    public int owningPlayer;
    public int pointCost;
    public Texture unitTexture;

    public UnitClass()
    {
        uC = className.className1;
        uT = classType.classType1;
        att = 0;
        def = 0;
        owningPlayer = 0;
        pointCost = 0;
        unitTexture = null;
    }

    public void unitSetup(className cn, classType ct, float a, float d, int pl, int p, Texture tex)
    {
        uC = cn;
        uT = ct;
        att = a;
        def = d;
        owningPlayer = pl;
        pointCost = p;
        texture = tex;
        TextureManager.applyTexture(this.gameObject, texture);
    }

    public void unitSetup(UnitClass copy)
    {
        uC = copy.unitClass;
        uT = copy.unitType;
        att = copy.attack;
        def = copy.defense;
        owningPlayer = copy.owner;
        pointCost = copy.cost;
        texture = copy.texture;
        TextureManager.applyTexture(this.gameObject, texture);
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

    public Texture texture
    {
        get
        {
            return unitTexture;
        }
        set
        {
            unitTexture = value;
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
}