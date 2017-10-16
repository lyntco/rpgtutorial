using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour {
	public int questNumber;
	private QuestManager questManager;
	public string itemName;

	void Start () {
		questManager = FindObjectOfType<QuestManager>();
	}

	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			if (!questManager.questsCompleted[questNumber] &&
					questManager.quests[questNumber].gameObject.activeSelf) {
					questManager.itemCollected = itemName;
					gameObject.SetActive(false);
			}
		}
	}
}
