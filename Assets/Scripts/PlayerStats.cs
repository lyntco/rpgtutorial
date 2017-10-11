using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
	public int currentLevel;
	public int currentExp;

	public int[] toLevelUp;
	public int[] hpLevels;
	public int[] attackLevels;
	public int[] defenseLevels;

	public int currentHP;
	public int currentAttack;
	public int currentDefense;

	void Start () {

	}

	void Update () {
		if (currentExp >= toLevelUp[currentLevel]) {
			currentLevel++;
		}
	}

	public void AddExperience(int experienceToAdd) {
		currentExp += experienceToAdd;
	}
}
