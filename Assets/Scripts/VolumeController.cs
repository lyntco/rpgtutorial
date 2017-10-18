using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour {
	private AudioSource audioSource;
	private float audioLevel;
	public float defaultAudio;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	void Update () {

	}

	public void SetAudioLevel(float volume) {
		if (audioSource == null) {
			audioSource = GetComponent<AudioSource>();
		}
		audioLevel = defaultAudio * volume;
		audioSource.volume = audioLevel;
	}
}
