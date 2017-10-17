using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
	public GameObject dialogueBox;
	public Text dialogueText;

	public bool dialogueActive;
	public string[] dialogueLines;
	public int currentLine;

	private PlayerController player;

	void Start () {
		dialogueBox.SetActive(false);
		currentLine = 0;
		player = FindObjectOfType<PlayerController>();
	}

	void Update () {
		if (dialogueActive && Input.GetKeyUp(KeyCode.Space)) {
			currentLine++;
		}
		if (currentLine >= dialogueLines.Length) {
			dialogueActive = false;
			dialogueBox.SetActive(false);
			currentLine = 0;
			player.canMove = true;
		}
		dialogueText.text = dialogueLines[currentLine];
	}

	public void ShowDialogue() {
		dialogueActive = true;
		dialogueBox.SetActive(true);
		player.canMove = false;
	}
}
