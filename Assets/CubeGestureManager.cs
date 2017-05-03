using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using TouchScript.Hit;
using DG.Tweening;

public class CubeGestureManager : MonoBehaviour {

	public TransformGesture transformGesture;
	private Rigidbody rigidBody;
	private Collider collider;
	public TapGesture singleTap;
	public TapGesture doubleTap;
	private Animator animatorController;
	private bool shakestart = false;
	private float shake = 0f;
	private float stage_three = 10f;

	// Use this for initialization
	void Start () {
		rigidBody = this.GetComponent<Rigidbody> ();
		collider = this.GetComponent<CapsuleCollider> ();
		animatorController = this.GetComponent<Animator> ();
		//collider = this.GetComponent<BoxCollider> ();

		transformGesture.TransformStarted += (object sender, System.EventArgs e) => {
			rigidBody.useGravity = false;
			rigidBody.velocity = Vector3.zero;
			collider.enabled = false;
		};

		transformGesture.Transformed += (object sender, System.EventArgs e) => {
			//this.transform.position += transformGesture.DeltaPosition;
			this.transform.Rotate (new Vector3 (0, 1, 0), -transformGesture.DeltaPosition.x*60f);
			this.transform.localScale *= transformGesture.DeltaScale;
		};

		transformGesture.TransformCompleted += (object sender, System.EventArgs e) => {
			rigidBody.useGravity = true;
			collider.enabled = true;
		};
			
		singleTap.Tapped += (object sender, System.EventArgs e) => {
			Debug.Log("Single");
			animatorController.SetTrigger("jump");
		};

		doubleTap.Tapped += (object sender, System.EventArgs e) => {
			Debug.Log("Double");
			animatorController.SetTrigger("fall");
		};
	}
	
	// Update is called once per frame
	void Update () {
		float leftandright = Input.acceleration.x;
		//Debug.Log (leftandright);
		if(leftandright > 1.2 || leftandright < -1.2){
			Debug.Log ("Shake");
			animatorController.SetTrigger ("walk");
		}
		
	}
}
