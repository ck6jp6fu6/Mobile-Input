using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangebySound : MonoBehaviour {

	public Material meterial;
	public MicroPhoneInput micInput;
	const float maxLoud = 0.2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float value = (maxLoud - micInput.MicLoudness*100f) / maxLoud;
		if (value < 0)
			value = 0;
		meterial.color = new Color (value, (1 - value), (1 - value));
	}
}
