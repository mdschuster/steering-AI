using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour{

	//Baisc AI Script for use with unity object
	SteeringAICore AICore;
	Kinematic target;
	Kinematic myKinematic;
	KinematicSteeringOutput KSO;

	//overloaded initializers
	public void init(SteeringAICore AICore){
		this.AICore=AICore;
		this.myKinematic=GetComponent<Mover> ().myKinematic;
	}

	public void init(SteeringAICore AICore, Kinematic target){
		this.AICore = AICore;
		this.target = target;
	}

	public void init(){
		this.AICore=new Seek();
	}

	//set a new target for the AI
	public void setTarget(Kinematic target){
		this.target = target;
	}

	public Kinematic getTarget(){
		return this.target;
	}

	//Change the AI type, must be a kind of KinematicAICore
	public void setAI(SteeringAICore AICore){
		if (this.AICore != null) {
			this.AICore = null;
		}
		this.AICore = AICore;
	}
	//sets new AI based on string name \\FIXME use a dictionary instead?
	public void setAI(string AICore){
		if (this.AICore != null) {
			this.AICore = null;
		}
		if (AICore == "Seek") {
			this.AICore = new Seek ();
		} else if (AICore == "Flee") {
			this.AICore = new Flee ();
		} else {
			this.AICore = new Seek ();
		}
	}

	public KinematicSteeringOutput getSteering(Kinematic self){
		if (this.target == null) {
			//if there is no target, set it to yourself
			this.target = self;
		}
		KSO = AICore.getSteering(self,this.target);
		return this.KSO;
	}

	public void setAccel(float accel){
		AICore.MaxAccel = accel;
	}
}
