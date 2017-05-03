using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	public Camera mainCamera;

	void Start(){
		Input.gyro.enabled = true;
	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Input.touches.Length; i++) {
			//Debug.Log ("Point " + Input.touches [i].fingerId + ":" + Input.touches [i].position);
			Vector3 screenPos = Input.touches [i].position;

			screenPos.z = this.transform.position.z - mainCamera.transform.position.z;

			Vector3 TargetPos = mainCamera.ScreenToWorldPoint (screenPos);
			this.transform.position = TargetPos;
		}
		Vector3 dir = Vector3.zero;

		dir.x = -Input.acceleration.y;
		dir.z = Input.acceleration.x;

		if (dir.sqrMagnitude > 1)
			dir.Normalize();

		Debug.Log(dir);
		//this.transform.rotation = ConvertRotation (Input.gyro.attitude);
		//Debug.Log (Input.gyro.attitude);
	}

	private Quaternion ConvertRotation(Quaternion q){
		return Quaternion.Euler (90, 0, 0) * new Quaternion (q.x, q.y, -q.z, -q.w);
	}
}
