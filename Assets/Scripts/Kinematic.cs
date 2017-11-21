using UnityEngine;
using System.Collections;

public class Kinematic {

	//kinematic variables
	Vector3 position;
	float orientation;
	Vector3 velocity;
	float rotation;

	float maxSpeed;


	public void update(KinematicSteeringOutput steering, float dt){
		//update position and orientation using velocity
		position += velocity * dt;
		orientation += rotation * dt;

		//and the velocity and rotation using acceleration
		velocity += steering.Linear * dt;
		rotation += steering.Angular * dt;

		//make sure we don't exceed the max speed
		if (velocity.magnitude > maxSpeed) {
			velocity = velocity.normalized* maxSpeed;
		}
	}

	public Vector3 Position {
		get {
			return position;
		}
		set {
			position = value;
		}
	}

	public float Orientation {
		get {
			return orientation;
		}
		set {
			orientation = value;
		}
	}

	public Vector3 Velocity {
		get {
			return velocity;
		}
		set {
			velocity = value;
		}
	}

	public float Rotation {
		get {
			return rotation;
		}
		set {
			rotation = value;
		}
	}

	public float MaxSpeed {
		get {
			return maxSpeed;
		}
		set {
			maxSpeed = value;
		}
	}
}
