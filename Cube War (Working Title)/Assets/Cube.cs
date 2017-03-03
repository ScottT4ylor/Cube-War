using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Just a basic bit of code to launch a cube
 * (pulled some code from Mission Demolition)
 */

//Enum for the current play state
/*
public enum CubeState{
	Idle, //The player is idle
	Aiming, //The player has selected a cude and is currently aiming
	Launch}; //The player has launched the cube, and the cube is in motion
	*/

public class Cube : MonoBehaviour {

	private PlayState playState;  //The current play state
	private Vector3 velocity; //The cube's velocity
	//private Rigidbody cubeBody;

	//private Vector3 mousePos2D;
	//private Vector3 mousePos3D;
	private Vector3 launcherPos;
	private float launcherY = 0.0f;
	private Vector3 cubePos;
	private GameObject tempLauncher;
	private GameObject tempHitMarker;
	private GameObject ground;
	private RaycastHit hit;
	private Ray ray;
	private Vector3 hitPos;
	private float maxHitPosY;
	private float minHitPosY;
	private float maxLauncherY;
	private float minLauncherY;

	public GameObject launcher;
	public GameObject hitPosMarker;
	public float velocityMulti = 4f; //Multiplyer for velocity
	public float hitPosMod = 0.02f;
	public float maxMagnitude = 5.0f;

	// Use this for initialization
	void Start () {
		playState = StateMachine.playState; 
		//cubePos = Camera.main.ScreenToWorldPoint (this.gameObject.transform.position);
		//cubePos = this.gameObject.GetComponent<Collider>().bounds.center;
		//mousePos2D = Input.mousePosition;
		//mousePos3D = Vector3.zero;
		//maxMagnitude = this.gameObject.GetComponent<Collider> ().bounds.size.x * 3f;
		velocity = Vector3.zero; //The player only controls X and Z velocity
		//cubeBody = this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
			
		StateMachine.playState = playState;
		switch (playState) {
		case PlayState.Idle:
			break;
		case PlayState.Aiming:
			UpdateLaunchVelocity ();
			//alter hit position
			if(Input.GetKey(KeyCode.Z)){
				if (hitPos.y < maxHitPosY) {
					hitPos.y += hitPosMod;
					launcherY += hitPosMod;
					if (hitPos.y > maxHitPosY) {
						hitPos.y = maxHitPosY;
					}
					if (hitPos.y > maxLauncherY) {
						launcherY = maxLauncherY;
					}
					tempHitMarker.transform.position = hitPos;
				}
			}
			if(Input.GetKey(KeyCode.X)){
				if (hitPos.y > minHitPosY) {
					hitPos.y -= hitPosMod;
					launcherY -= hitPosMod;
					if (hitPos.y < minHitPosY) {
						hitPos.y = minHitPosY;
					}
					if (hitPos.y < minLauncherY) {
						launcherY = minLauncherY;
					}
					tempHitMarker.transform.position = hitPos;
				}
			}

			//alter launcher pos
			if(Input.GetKey(KeyCode.C)){
				if (launcherY < maxLauncherY) {
					launcherY += hitPosMod;
					if (hitPos.y > maxLauncherY) {
						launcherY = maxLauncherY;
					}
				}
			}
			if(Input.GetKey(KeyCode.V)){
				if (hitPos.y > minLauncherY) {
					launcherY -= hitPosMod;
					if (hitPos.y < minLauncherY) {
						launcherY = minLauncherY;
					}
				}
			}

			//launch 
			if (Input.GetMouseButtonDown(0)) {
				isKinematic = false;
				this.gameObject.GetComponent<Rigidbody> ().AddForceAtPosition (-velocity * velocityMulti,hitPos);
				GameObject.Destroy (tempHitMarker);
				playState = PlayState.Launch;
			}
			break;
		case PlayState.Launch:
			GameObject.Destroy(tempLauncher);

			if (this.gameObject.GetComponent<Rigidbody> ().velocity.magnitude <= 0.01) {
				this.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;

				this.gameObject.transform.rotation = Quaternion.Euler (0, 0, 0);
				velocity = Vector3.zero;
				//cubePos = this.gameObject.transform.position;
				hitPos = this.gameObject.transform.position;
				launcherY = this.gameObject.transform.position.y;
				playState = PlayState.Idle;
			}
			break;
		}
	}



	void OnMouseDown(){
		if (playState == PlayState.Idle) {
			//TEMP
			//this.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3(30f,4f,30f);
			hitPos = this.gameObject.transform.position;
			launcherY = this.gameObject.transform.position.y;
			maxHitPosY = hitPos.y + this.gameObject.GetComponent<Renderer> ().bounds.extents.y;
			minHitPosY = hitPos.y - this.gameObject.GetComponent<Renderer> ().bounds.extents.y;
			maxLauncherY = maxHitPosY + this.gameObject.GetComponent<Renderer> ().bounds.extents.y;
			minLauncherY = minHitPosY - this.gameObject.GetComponent<Renderer> ().bounds.extents.y;

			//TESTING
			tempHitMarker = (GameObject)Instantiate(hitPosMarker,hitPos,Quaternion.identity);

			isKinematic = true;
			playState = PlayState.Aiming;
			//StateMachine.playState = playState;

			//might remove this later
		}
	}


	public bool isKinematic{
		get{
			return this.gameObject.GetComponent<Rigidbody> ().isKinematic;
		} 
		set{ this.gameObject.GetComponent<Rigidbody> ().isKinematic = value;
		}
	}	

	private void UpdateLaunchVelocity(){
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if ( Physics.Raycast (ray,out hit,1000.0f)) {
			launcherPos = new Vector3 (hit.point.x, launcherY, 
				hit.point.z);
		}
		/*
		mousePos2D = Input.mousePosition;
		mousePos2D.z = Camera.main.transform.position.y;
		//mousePos2D.z = cubePos.y;
		//mousePos2D.z = 1f;
		mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);
		*/
		GameObject.Destroy (tempLauncher);
		//mousePos3D.y = 0f;
		tempLauncher = (GameObject)Instantiate (launcher, launcherPos, Quaternion.Euler (0, 0, 0));
		//cubePos = Camera.main.ScreenToWorldPoint (this.gameObject.transform.position);
		velocity = launcherPos - hitPos;
		if (velocity.magnitude > maxMagnitude) {
			velocity = launcherPos.normalized * maxMagnitude;
			launcherPos = velocity + hitPos;
			tempLauncher.transform.position = launcherPos;
		}
		//do something about the y later
		//velocity.y = 0f; 
		//GameObject.Destroy (tempLauncher);
		//print ("" + mousePos3D + ", " + velocity);
		//since the camera has been rotated, we need to change the vector values
		/*float z = velocity.z;
		velocity.z = velocity.y;
		velocity.y = z;*/
	}





}
