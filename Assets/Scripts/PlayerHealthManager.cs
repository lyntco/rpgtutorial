using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {
	public int playerCurrentHealth;
	public int playerMaxHealth;

	void Start () {
		playerCurrentHealth = playerMaxHealth;
	}

	void Update () {
		if (playerCurrentHealth <= 0) {
			gameObject.SetActive(false);
		}
	}

	public void ChangePlayerHealth (int hitPoints) {
		playerCurrentHealth += hitPoints;
	}

	public void SetMaxHealth () {
		playerCurrentHealth = playerMaxHealth;
	}
}
