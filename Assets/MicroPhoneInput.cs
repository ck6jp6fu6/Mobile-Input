using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroPhoneInput : MonoBehaviour {

	public float MicLoudness;
	private string _device;
	AudioClip _clipRecord = new AudioClip();
	int _sampleWindow = 128;

	// Use this for initialization
	void Start () {
		if (_device == null)
			_device = Microphone.devices [0];
		_clipRecord = Microphone.Start (_device, true, 999, 44100);
	}

	void OnDestroy(){
		Microphone.End (_device);
	}

	float LevelMax(){
		float levelMax = 0;
		float[] waveData = new float[_sampleWindow];
		int micPosition = Microphone.GetPosition (null) - (_sampleWindow + 1);

		if (micPosition < 0)
			return 0;
		_clipRecord.GetData (waveData, micPosition);

		for (int i = 0; i < _sampleWindow; i++) {
			float wavePeak = waveData [i] * waveData [i];
			if (levelMax < wavePeak) {
				levelMax = wavePeak;
			}
		}
		return levelMax;
	}

	// Update is called once per frame
	void Update () {
		MicLoudness = LevelMax ();	
	}
}
