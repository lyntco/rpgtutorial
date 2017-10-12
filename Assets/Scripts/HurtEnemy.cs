using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {
	public Transform hitLocation;
	public int hitPointsChange;
	private int currentDamage;
	public GameObject damageBurst;
	public GameObject damageNumber;

	private PlayerStats playerStats;
	void Start () {
		playerStats = FindObjectOfType<PlayerStats>();
	}

	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			currentDamage = -(hitPointsChange - playerStats.currentAttack);
			other.gameObject.GetComponent<EnemyHealthManager>().ChangeHealth(-currentDamage);
			Instantiate(damageBurst, hitLocation.position, hitLocation.rotation);
			var clone = (GameObject) Instantiate(damageNumber, hitLocation.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
		}
	}
}
