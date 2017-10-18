using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {
	public int currentHealth;
	public int maxHealth;

	private SpriteRenderer sprite;
	private PlayerStats playerStats;
	public int expToGive;

	public string enemyName;
	private QuestManager questManager;

	public int maxGoldVal;
	public int minGoldVal;
	public GameObject coin;

	void Start () {
		currentHealth = maxHealth;
		sprite = GetComponent<SpriteRenderer>();
		playerStats = FindObjectOfType<PlayerStats>();
		questManager = FindObjectOfType<QuestManager>();
	}

	void Update () {
		if (currentHealth <= 0) {
			questManager.enemyKilled = enemyName;
			Destroy(gameObject);
			playerStats.AddExperience(expToGive);
			GameObject droppedCoin = Instantiate(coin, transform.position, transform.rotation);
			droppedCoin.GetComponent<CoinPickup>().value = Random.Range(minGoldVal, maxGoldVal);
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
