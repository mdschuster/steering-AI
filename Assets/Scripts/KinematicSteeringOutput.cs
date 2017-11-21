using UnityEngine;
using System.Collections;

public class KinematicSteeringOutput {
	Vector3 linear;
	float angular;

	public Vector3 Linear {
		get {
			return linear;
		}
		set {
			linear = value;
		}
	}

	public float Angular {
		get {
			return angular;
		}
		set {
			angular = value;
		}
	}
}
