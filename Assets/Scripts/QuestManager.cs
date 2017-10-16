using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public QuestObject[] quests;
	public bool[] questsCompleted;
	public DialogueManager dialogueMManager;

	void Start () {
		questsCompleted = new bool[quests.Length];
	}

	void Update () {

	}

	public void ShowQuestText(string questText) {
		dialogueMManager.dialogueLines = new string[1];
		dialogueMManager.dialogueLines[0] = questText;
		dialogueMManager.currentLine = 0;
		dialogueMManager.ShowDialogue();
	}
}
