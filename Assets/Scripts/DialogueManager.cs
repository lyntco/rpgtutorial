using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
	public GameObject dialogueBox;
	public Text dialogueText;

	public bool dialogueActive;

	void Start () {
		dialogueBox.SetActive(false);
	}

	void Update () {
		if (dialogueActive && Input.GetKeyDown(KeyCode.Space)) {
			dialogueBox.SetActive(false);
			dialogueActive = false;
		}
	}

	public void ShowBox(string text) {
		dialogueActive = true;
		dialogueBox.SetActive(true);
		dialogueText.text = text;
	}
}
