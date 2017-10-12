using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {
	public int damagePoints;
	public GameObject damageNumber;
	private PlayerStats playerStats;
	private int currentDamage;

	void Start () {
		playerStats = FindObjectOfType<PlayerStats>();
	}

	void Update () {

	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.name == "Player") {
			currentDamage = damagePoints - playerStats.currentDefense;
			if (currentDamage <= 0) {
				currentDamage = 1;
			}
			other.gameObject.GetComponent<PlayerHealthManager>().ChangePlayerHealth(-currentDamage);
			var clone = (GameObject) Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
		}
	}
}
