using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeKillBox : MonoBehaviour {
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Cube"))
        {
			if (collision.gameObject.GetComponent<Cube> ().playState == PlayState.launch) {
				GameDriver.checkCubeMovement();
			} 
            GameDriver.removeCubeFromPlay(collision.gameObject);
        }
    }
}
