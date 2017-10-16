using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour {
	private QuestManager questManager;
	public int questNumber;
	public bool isStart;
	public bool isEnd;

	void Start () {
		questManager = FindObjectOfType<QuestManager>();
	}

	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.name == "Player") {
			if (!questManager.questsCompleted[questNumber]) {
				QuestObject quest = questManager.quests[questNumber];
				if (isStart && !quest.gameObject.activeSelf) {
					quest.gameObject.SetActive(true);
					quest.StartQuest();
				}
				if (isEnd && quest.gameObject.activeSelf) {
					quest.EndQuest();
				}
			}
		}
	}
}
