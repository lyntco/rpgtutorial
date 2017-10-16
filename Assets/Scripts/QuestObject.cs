using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {
	public int questNumber;
	public QuestManager questManager;
	public string startText;
	public string endText;

	public bool isItemQuest;
	public string targetItem;

	public bool isEnemyKillQuest;
	public string targetEnemy;
	public int enemiesToKill;
	private int enemyKillCount;

	void Start () {

	}

	void Update () {
		if (isItemQuest) {
			if (questManager.itemCollected == targetItem) {
				questManager.itemCollected = null;
				EndQuest();
			}
		}

		if (isEnemyKillQuest) {
			if(questManager.enemyKilled == targetEnemy) {
				questManager.enemyKilled = null;
				enemyKillCount++;
			}
			if (enemyKillCount >= enemiesToKill) {
				EndQuest();
			}
		}
	}

	public void StartQuest() {
		questManager.ShowQuestText(startText);
	}

	public void EndQuest() {
		questManager.ShowQuestText(endText);
		questManager.questsCompleted[questNumber] = true;
		gameObject.SetActive(false);
	}
}
