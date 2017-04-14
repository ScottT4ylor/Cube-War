using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchLine : MonoBehaviour {
	public static LaunchLine launchLine;

	// Use this for initialization
	void Start () {
		launchLine = this;
		Enabled (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Enabled(bool enable){
		this.gameObject.GetComponent<LineRenderer> ().enabled = enable;
	}

	public void SetPosition(int index,Vector3 pos){
		this.gameObject.GetComponent<LineRenderer> ().SetPosition (index, pos);
	}

	public Color endColor{
		get{ return this.gameObject.GetComponent<LineRenderer> ().endColor;}
		set{ this.gameObject.GetComponent<LineRenderer> ().endColor = value;}
	}
}
