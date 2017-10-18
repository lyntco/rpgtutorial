using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {
	public Text moneyText;
	public int currentGold;

	void Start () {
		if (PlayerPrefs.HasKey("CurrentMoney")) {
			currentGold = PlayerPrefs.GetInt("CurrentMoney");
		} else {
			currentGold = 0;
			PlayerPrefs.SetInt("CurrentMoney", 0);
		}
		moneyText.text = "GOLD: " + currentGold;
	}

	public void UpdateMoney(int moneyChange) {
		currentGold += moneyChange;
		PlayerPrefs.SetInt("CurrentMoney", currentGold);
		moneyText.text = "GOLD: " + currentGold;
	}
}
