using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverInterface : MonoBehaviour {

	public void gameOver(int winner)
    {
        GetComponent<Text>().text = "Player " + winner + " wins!";
    }
}
