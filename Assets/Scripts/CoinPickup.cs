using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {
	public int value;
	private MoneyManager moneyManager;

	void Start () {
		moneyManager = FindObjectOfType<MoneyManager>();
	}

	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			moneyManager.UpdateMoney(value);
			Destroy(gameObject);
		}
	}
}
