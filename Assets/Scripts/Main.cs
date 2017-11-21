using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	//World world;
	GameObject block1;
	GameObject block2;

	// Use this for initialization
	void Start () {

		//world = new World ();

		block1 = GameObject.Find ("Cube1");  //red
		block2 = GameObject.Find ("Cube2");  //blue
		Mover b1Mover = block1.GetComponent<Mover> ();
		Mover b2Mover = block2.GetComponent<Mover> ();
		b1Mover.init ();
		b2Mover.init ();
		AI b1AI = block1.GetComponent<AI>();
		AI b2AI = block2.GetComponent<AI>();



		if (block2.GetComponent<Mover> ().myKinematic==null) {
			Debug.Log ("NULL block character");
		}

		b1AI.setAI ("Arrive");
		b2AI.setAI ("Flee");
		b1Mover.setSpeed (10f, 5f, 50f);
		b2Mover.setSpeed (5f, 5f, 50f);
		b1AI.setTarget (block2.GetComponent<Mover>().myKinematic);
		b2AI.setTarget (block1.GetComponent<Mover> ().myKinematic);

	}

	// Update is called once per frame
	void Update () {
	}
}
