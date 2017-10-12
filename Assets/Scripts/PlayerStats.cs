using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
	public int currentLevel;
	public int currentExp;
	public int currentHP;
	public int currentAttack;
	public int currentDefense;

	public int[] toLevelUp;
	public int[] hpLevels;
	public int[] attackLevels;
	public int[] defenseLevels;

	private PlayerHealthManager playerHealth;

	void Start () {
		currentHP = hpLevels[1];
		currentAttack = attackLevels[1];
		currentDefense = defenseLevels[1];
		playerHealth = FindObjectOfType<PlayerHealthManager>();
	}

	void Update () {
		if (currentExp >= toLevelUp[currentLevel]) {
			LevelUp();
		}
	}

	public void AddExperience(int experienceToAdd) {
		currentExp += experienceToAdd;
	}

	void LevelUp() {
		currentLevel++;
		currentHP = hpLevels[currentLevel];
		playerHealth.playerMaxHealth = currentHP;
		playerHealth.playerCurrentHealth = currentHP;
		currentAttack = attackLevels[currentLevel];
		currentDefense = defenseLevels[currentLevel];
	}
}
