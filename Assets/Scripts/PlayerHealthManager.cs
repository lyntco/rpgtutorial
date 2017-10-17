using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {
	public int playerCurrentHealth;
	public int playerMaxHealth;

	public bool flashActive;
	public float flashLength;
	private float flashCounter;

	private SpriteRenderer playerSprite;
	private SFXManager sFXManager;

	void Start () {
		playerCurrentHealth = playerMaxHealth;
		playerSprite = GetComponent<SpriteRenderer>();
		sFXManager = FindObjectOfType<SFXManager>();
	}

	void Update () {
		if (playerCurrentHealth <= 0) {
			sFXManager.playerDead.Play();
			gameObject.SetActive(false);
		}

		if (flashActive) {
			if (flashCounter > flashLength * .66f) {
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, .2f);
			} else if (flashCounter > flashLength * .33f) {
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
			} else if (flashCounter > flashLength * .0f) {
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, .2f);
			}
			if (flashCounter < 0) {
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
				flashActive = false;
			}
			flashCounter -= Time.deltaTime;
		}
	}

	public void ChangePlayerHealth (int hitPoints) {
		playerCurrentHealth += hitPoints;
		if (hitPoints < 0) {
			flashActive = true;
			flashCounter = flashLength;
			sFXManager.playerHurt.Play();
		}
	}

	public void SetMaxHealth () {
		playerCurrentHealth = playerMaxHealth;
	}
}
