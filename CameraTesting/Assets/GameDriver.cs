using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDriver : MonoBehaviour {
    public static GameDriver gameDriver;
    public Player p1;
    public Player p2;
    public int playerPointsTesting = 100; // Change how this is done later once we know how to determine this.
    public GameObject cubeSelected;
    public List<GameObject> cubesInPlay;

    public void Awake()
    {
        gameDriver = this;
        beginGameSetup();
    }

    public void beginGameSetup()
    {
        p1 = new Player(1, playerPointsTesting);
        p2 = new Player(2, playerPointsTesting);
        StateMachine.activate();
        StateMachine.setupPhase();
        StateMachine.initiateTurns();
    }

    public int addPlayerPoints(int player, int points)
    {
        switch(player)
        {
            case 1:
                p1.currentPoints += points;
                return p1.currentPoints;
            case 2:
                p2.currentPoints += points;
                return p2.currentPoints;
            default:
                return -1;
        }
    }

    public int getPlayerPoints()
    {
        if (StateMachine.currentTurn() == 1)
        {
            return p1.points;
        }
        else if (StateMachine.currentTurn() == 2)
        {
            return p2.points;
        }
        else
        {
            print("Tried to get player's points, it didn't work.");
            return -1;
        }
    }

    public int getMaxPlayerPoints()
    {
        if (StateMachine.currentTurn() == 1)
        {
            return p1.pointsAvailable;
        }
        else if (StateMachine.currentTurn() == 2)
        {
            return p2.pointsAvailable;
        }
        else
        {
            print("Tried to get player's points, it didn't work.");
            return -1;
        }
    }

    public int getPlayerPointsRemaining()
    {
        if (StateMachine.currentTurn() == 1)
        {
            return (p1.pointsAvailable - p1.points);
        }
        else if (StateMachine.currentTurn() == 2)
        {
            return (p2.pointsAvailable - p2.points);
        }
        else
        {
            print("Tried to get player's points, it didn't work.");
            return -1;
        }
    }

    public void placingCube(GameObject toPlace)
    {
        cubeSelected = toPlace;
        //cubeSelected.GetComponent<Cube>().cubePlayState = PlayState.placing; Leaving this commented out because I don't have the cube script available.
    }

    public static void startBattle()
    {
        StateMachine.battlePhase();
        StateMachine.initiateTurns();
    }








    //////////////////Static stuff for calling easily from outside//////////////////////////////////
    

    //
    //Call this from the cube when it is placed
    //
    public static void placedCube()
    {
        if (gameDriver.addPlayerPoints(StateMachine.currentTurn(),gameDriver.cubeSelected.GetComponent<UnitClass>().cost) == -1)
            print("Something went wrong with the player point counts!");
        gameDriver.cubesInPlay.Add(gameDriver.cubeSelected);
        gameDriver.cubeSelected = null;
        StateMachine.passTurn();
    }



    //
    //Call this from the cube when placement is cancelled
    //
    public static void cancelPlaceCube()
    {
        GameObject.Destroy(gameDriver.cubeSelected);
        gameDriver.cubeSelected = null;
    }

    //
    //Call this on turn change to clear the flick count of cubes for the next turn
    //
    public static void clearFlicks()
    {
        foreach (GameObject c in gameDriver.cubesInPlay)
        {
            /*if (StateMachine.getPhase() == GamePhase.battle)
            {
                if (c.GetComponent<Cube>().stunned == false)
                {
                    c.GetComponent<Cube>().flicked = false;
                }
                else
                {
                    c.GetComponent<Cube>().stunned = false;
                }
            }*/ //Currently commented out because I don't have the cubes in this project. Uncomment this when they're integrated.
        }
    }



    //
    //Call this to get a reference to this script
    //
    public static GameDriver getGameDriverRef()
    {
        return gameDriver;
    }

    
}
