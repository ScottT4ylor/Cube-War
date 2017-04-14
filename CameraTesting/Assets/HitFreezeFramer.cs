using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFreezeFramer : MonoBehaviour {
    public static HitFreezeFramer h;
    public static int frames;

    private void Awake()
    {
        h = this;
    }

	void Update () {
        if(frames > 0)
        {
            frames--;
            if(frames == 0)
            {
                Time.timeScale = 1;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                enabled = false;
            }
        }
	}

    public static void freezeFrame(int num)
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
        frames = num;
        h.enabled = true;
    }
}
