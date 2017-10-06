﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {
	public int currentHealth;
	public int maxHealth;

	private SpriteRenderer sprite;

	void Start () {
		currentHealth = maxHealth;
		sprite = GetComponent<SpriteRenderer>();
	}

	void Update () {
		if (currentHealth <= 0) {
			Destroy(gameObject);
		}
	}

	public void ChangeHealth (int hitPoints) {
		bool positive = Mathf.Sign(hitPoints) == 1;
		if (positive) {
			FlashColors(Color.green);
		} else {
			FlashColors(Color.red);
		}
		currentHealth += hitPoints;
	}

	IEnumerator Wait (float waitTime) {
		yield return new WaitForSeconds(waitTime);
		sprite.color = Color.white;
	}

	private void FlashColors (Color flash) {
		sprite.color = flash;
		StartCoroutine(Wait(0.5f));
	}

	public void SetMaxHealth () {
		currentHealth = maxHealth;
	}
}
