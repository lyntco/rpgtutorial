using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour {
	public VolumeController[] volumeControllers;
	public float maxVolume = 1.0f;
	public float currentVolume;

	void Start () {
		volumeControllers = FindObjectsOfType<VolumeController>();
		if (currentVolume > maxVolume) {
			currentVolume = maxVolume;
		}

		for (int i = 0; i < volumeControllers.Length; i++) {
			volumeControllers[i].SetAudioLevel(currentVolume);
		}
	}

	void Update () {

	}
}
