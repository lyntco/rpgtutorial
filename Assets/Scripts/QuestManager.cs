using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public QuestObject[] quests;
	public bool[] questsCompleted;
	public DialogueManager dialogueManager;
	public string itemCollected;
	public string enemyKilled;

	void Start () {
		questsCompleted = new bool[quests.Length];
	}

	void Update () {

	}

	public void ShowQuestText(string questText) {
		dialogueManager.dialogueLines = new string[1];
		dialogueManager.dialogueLines[0] = questText;
		dialogueManager.currentLine = 0;
		dialogueManager.ShowDialogue();
	}
}
