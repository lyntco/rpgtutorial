using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
	private SFXManager sFXManager;
	private static bool musicControllerExists;
	public AudioSource[] musicTracks;
	public int currentTrack;

	public bool musicCanPlay;

	void Start () {
		if (!musicControllerExists) {
			musicControllerExists = true;
			DontDestroyOnLoad(transform.gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	void Update () {
		if (musicCanPlay) {
			if (!musicTracks[currentTrack].isPlaying) {
				musicTracks[currentTrack].Play();
			}
		} else {
			musicTracks[currentTrack].Stop();
		}
	}

	public void SwitchTrack(int trackNumber) {
		musicTracks[currentTrack].Stop();
		currentTrack = trackNumber;
	}
}
