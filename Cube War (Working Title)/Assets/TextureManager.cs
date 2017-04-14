using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureManager : MonoBehaviour {

    public static void applyTexture(GameObject obj, Texture tex)
    {
        if (tex != null)
            obj.GetComponent<Renderer>().material.SetTexture(Shader.PropertyToID("_MainTex"), tex);
        else
            print("Can't apply texture, the texture you passed in is null!");
	}



}
