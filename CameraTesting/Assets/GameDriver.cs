using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDriver : MonoBehaviour {


    public void Awake()
    {
        StateMachine.activate();
        StateMachine.setupPhase();
        StateMachine.initiateTurns();
    }
    
}
