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

	void Start () {
		dialogueBox.SetActive(false);
		currentLine = 0;
	}

	void Update () {
		if (dialogueActive && Input.GetKeyUp(KeyCode.Space)) {
			dialogueText.text = dialogueLines[currentLine];
			currentLine++;
		}
		if (currentLine >= dialogueLines.Length) {
			dialogueBox.SetActive(false);
			dialogueActive = false;
			currentLine = 0;
		}
	}

	public void ShowBox(string text) {
		dialogueActive = true;
		dialogueBox.SetActive(true);
		dialogueText.text = text;
	}

	public void ShowDialogue() {
		dialogueActive = true;
		dialogueBox.SetActive(true);
	}
}
