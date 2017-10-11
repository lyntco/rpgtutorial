using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {
	public int damagePoints;
	public GameObject damageNumber;

	void Start () {

	}

	void Update () {

	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.name == "Player") {
			other.gameObject.GetComponent<PlayerHealthManager>().ChangePlayerHealth(-damagePoints);
			var clone = (GameObject) Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
			clone.GetComponent<FloatingNumbers>().damageNumber = damagePoints;
		}
	}
}
