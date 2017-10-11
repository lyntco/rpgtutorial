using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public Slider healthBar;
	public Text HPText;
	public Text LevelText;
	public PlayerHealthManager playerHealth;

	private static bool UIExists;
	private PlayerStats playerStats;

	void Start () {
		if (!UIExists) {
			UIExists = true;
			DontDestroyOnLoad(transform.gameObject);
		} else {
			Destroy(gameObject);
		}
		playerStats = GetComponent<PlayerStats>();
	}

	void Update () {
		int maxHealth = playerHealth.playerMaxHealth;
		int currentHealth = playerHealth.playerCurrentHealth;
		healthBar.maxValue = maxHealth;
		healthBar.value = currentHealth;
		HPText.text = "HP:" + currentHealth + "/" + maxHealth;
		LevelText.text = "LVL:" + playerStats.currentLevel;
	}
}
