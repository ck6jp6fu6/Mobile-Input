using System.Collections;
using System.Collections.Generic;
using TouchScript.Hit;
using UnityEngine;
using TouchScript.Gestures;
using DG.Tweening;

public class PlaneGestureManager : MonoBehaviour {

	public TransformGesture transformGesture;
	public GameObject girl1;
	public GameObject girl2;
	private bool change = true;

	// Use this for initialization
	void Start () {
		transformGesture.Transformed += (object sender, System.EventArgs e) => {
			Debug.Log(transformGesture.DeltaPosition);
			if(transformGesture.DeltaPosition.magnitude <= 0.2 && transformGesture.DeltaPosition.magnitude > 0){
				girl1.gameObject.SetActive(!change);
				girl2.gameObject.SetActive(change);
				change = !change;
			}
				
		};

	}
		
	// Update is called once per frame
	void Update () {
		
	}
}
