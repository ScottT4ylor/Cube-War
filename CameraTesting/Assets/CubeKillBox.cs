using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeKillBox : MonoBehaviour {
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Cube"))
        {
            GameDriver.removeCubeFromPlay(collision.gameObject);
            GameDriver.checkCubeMovement();
        }
    }
}
