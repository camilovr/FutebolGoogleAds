using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesManager : MonoBehaviour {

	private SliderJoint2D spike;
	private JointMotor2D aux;


	// Use this for initialization
	void Start () {
		spike = GetComponent<SliderJoint2D> ();
		aux = spike.motor;
	}
	
	// Update is called once per frame
	void Update () {
		if(spike.limitState==JointLimitState2D.UpperLimit){
			aux.motorSpeed = Random.Range (-1,-5);
			spike.motor = aux;
		}
		if(spike.limitState==JointLimitState2D.LowerLimit){
			aux.motorSpeed = Random.Range (1,5);
			spike.motor = aux;
		}
	}
}
