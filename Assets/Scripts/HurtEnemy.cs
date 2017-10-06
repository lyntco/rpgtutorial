using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {
	public Transform hitLocation;
	public int hitPointsChange;
	public GameObject damageBurst;
	void Start () {

	}

	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			// Destroy(other.gameObject); // KILL THE ENEMY
			other.gameObject.GetComponent<EnemyHealthManager>().ChangeHealth(-hitPointsChange);
			Instantiate(damageBurst, hitLocation.position, hitLocation.rotation);
		}
	}
}
