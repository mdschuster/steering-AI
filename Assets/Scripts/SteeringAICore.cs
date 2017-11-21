using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringAICore : MonoBehaviour {

	//holds data for char and target
	Kinematic character;
	Kinematic target;

	//holds default max speed
	float maxspeed=10f;
	float maxrotation=5f;
	float maxAccel=2f;
	float radius=0.1f;
	float timeToTarget=0.5f;

	protected abstract Vector3 getTargetVector (Vector3 charPos, Vector3 targetPos);
	protected abstract Vector3 getAccel (KinematicSteeringOutput steering);
	protected abstract float getRotation ();
	public abstract KinematicSteeringOutput getSteering (Kinematic character, Kinematic target);


	public float getNewOrientation(KinematicSteeringOutput steering){
		if (this.character.Velocity.magnitude == 0) {
			return (float)Mathf.Atan2 (steering.Linear.x, steering.Linear.z);
		} else {
			return this.character.Orientation;
		}
	}


	public Kinematic Character {
		get {
			return character;
		}
		set {
			character = value;
		}
	}

	public Kinematic Target {
		get {
			return target;
		}
		set {
			target = value;
		}
	}

	public float MaxAccel {
		get {
			return maxAccel;
		}
		set {
			maxAccel = value;
		}
	}

	public float Maxspeed {
		get {
			return maxspeed;
		}
		set {
			maxspeed = value;
		}
	}

	public float Maxrotation {
		get {
			return maxrotation;
		}
		set {
			maxrotation = value;
		}
	}

	public float Radius {
		get {
			return radius;
		}
		set {
			radius = value;
		}
	}

	public float TimeToTarget {
		get {
			return timeToTarget;
		}
		set {
			timeToTarget = value;
		}
	}
}

public class Seek : SteeringAICore{
	
	public override KinematicSteeringOutput getSteering(Kinematic character, Kinematic target){
		//create steering object
		KinematicSteeringOutput steering = new KinematicSteeringOutput ();
		base.Character = character;
		base.Target = target;

		//set the direction to target
		if (character == null) {
			Debug.Log ("NULL character");
		}
		if(target==null){
			Debug.Log("Warning: NULL target");
		}

		steering.Linear = getTargetVector (character.Position, target.Position);

		//compute the acceleration
		steering.Linear=getAccel(steering);

		if (steering.Linear.magnitude == 0f) {
			return steering;
		}

		//face in direction we want to move //FIXME
		//character.Orientation=getNewOrientation(steering);

		//output the steering
		steering.Angular=getRotation();

		return steering;
	}

	protected override Vector3 getTargetVector (Vector3 charPos, Vector3 targetPos)
	{
		return targetPos - charPos;
	}

	protected override Vector3 getAccel (KinematicSteeringOutput steering)
	{
		return steering.Linear.normalized*base.MaxAccel;
	}

	protected override float getRotation ()
	{
		return 0f;
	}

}

public class Flee : Seek{


	protected override Vector3 getTargetVector (Vector3 charPos, Vector3 targetPos)
	{
		return charPos - targetPos;
	}

}

