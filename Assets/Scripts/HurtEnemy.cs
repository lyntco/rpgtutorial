using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

	private GameObject enemy;
	void Start () {

	}

	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			Destroy(other.gameObject); // KILL THE ENEMY
			enemy = other.gameObject;
		}
	}
}
