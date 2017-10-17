using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {
	public AudioSource playerHurt;
	public AudioSource playerDead;
	public AudioSource playerAttacking;

	private static bool sFXManagerExists;
	void Start () {
		if (!sFXManagerExists) {
			sFXManagerExists = true;
			DontDestroyOnLoad(transform.gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	void Update () {

	}
}
