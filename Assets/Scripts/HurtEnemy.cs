using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {
	public Transform hitLocation;
	public int hitPointsChange;
	public GameObject damageBurst;
	public GameObject damageNumber;
	void Start () {

	}

	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<EnemyHealthManager>().ChangeHealth(-hitPointsChange);
			Instantiate(damageBurst, hitLocation.position, hitLocation.rotation);
			var clone = (GameObject) Instantiate(damageNumber, hitLocation.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers>().damageNumber = hitPointsChange;
		}
	}
}
