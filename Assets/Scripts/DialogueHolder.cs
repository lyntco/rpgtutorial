using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {
	public string dialogue;
	private DialogueManager dialogueManager;
	public string[] dialogueLines;

	void Start () {
		dialogueManager = FindObjectOfType<DialogueManager>();
	}

	void Update () {

	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			if (Input.GetKeyUp(KeyCode.Space)) {
				// dialogueManager.ShowBox(dialogue);
				if (!dialogueManager.dialogueActive) {
					dialogueManager.dialogueLines = dialogueLines;
					dialogueManager.currentLine = 0;
					dialogueManager.ShowDialogue();
				}
			}
		}
	}
}
