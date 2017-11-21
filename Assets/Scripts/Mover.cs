using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public Kinematic myKinematic;
	KinematicSteeringOutput steering;
	AI myAI;
	float maxSpeed;
	float maxRotation;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3 ();
		pos = myKinematic.Position;
		steering = myAI.getSteering (this.myKinematic);
		myKinematic.update (steering,Time.deltaTime);
		pos = myKinematic.Position;
		//check boundaries
		if (pos.x > 25.0f) {
			pos.x = -25.0f;
		}
		if (pos.x < -25.0f) {
			pos.x = 25.0f;
		}

		if (pos.z > 25.0f) {
			pos.z = -25.0f;
		}
		if (pos.z < -25.0f) {
			pos.z = 25.0f;
		}
		myKinematic.Position = pos;
		this.transform.position=pos;
		this.transform.eulerAngles = new Vector3 (0f, myKinematic.Orientation*180f/Mathf.PI, 0f);
		//Debug.Log ("BLOCK POSITION: " + pos);


	}

	public void init(){
		myAI = GetComponent<AI> ();
		myKinematic=new Kinematic();
		myKinematic.Position = this.transform.position;
		myKinematic.Velocity = new Vector3 (0f, 0f, 0f);
		myKinematic.Rotation = 0f;
		myKinematic.Orientation = 0f;
	}

	//allows setting the max speed and max rotation allowed by this AI
	public void setSpeed(float maxSpeed, float maxRotation, float maxAccel){
		myKinematic.MaxSpeed = maxSpeed;
		myAI.setAccel(maxAccel);
		myAI.setMaxSpeed (maxSpeed);
	}

}