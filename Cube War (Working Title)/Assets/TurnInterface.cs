using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnInterface : MonoBehaviour {
    public Text turnText;

    public void Awake()
    {
        turnText = GetComponent<Text>();
    }

    public void updateTurnInterface()
    {
        if (StateMachine.getGameState() == GameState.active)
        {
            
            if (StateMachine.currentTurn() == 1)
            {
                turnText.text = "Player 1";
            }
            else if (StateMachine.currentTurn() == 2)
            {
                turnText.text = "Player 2";
            }
        }
    }
}
