using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public Slider healthBar;
	public Text HPText;
	public PlayerHealthManager playerHealth;

	private static bool UIExists;

	void Start () {
		if (!UIExists) {
			UIExists = true;
			DontDestroyOnLoad(transform.gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	void Update () {
		int maxHealth = playerHealth.playerMaxHealth;
		int currentHealth = playerHealth.playerCurrentHealth;
		healthBar.maxValue = maxHealth;
		healthBar.value = currentHealth;
		HPText.text = "HP:" + currentHealth + "/" + maxHealth;
	}
}
