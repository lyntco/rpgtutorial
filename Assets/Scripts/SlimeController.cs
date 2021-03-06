﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour {
	public float moveSpeed;
	public float timeBetweenMove;
	public float timeToMove;
	public float waitToReload;

	private Rigidbody2D rigidbody;
	private bool moving;
	private Vector3 moveDirection;
	private float timeBetweenMoveCounter;
	private float timeToMoveCounter;
	private bool reloading;
	private GameObject player;

	private bool canMove;
	private DialogueManager dialogueManager;

	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		// timeBetweenMoveCounter = timeBetweenMove;
		// timeToMoveCounter = timeToMove;
		timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.15f, timeBetweenMove * 1.55f);
		timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
		moving = Random.value < 0.5;
		dialogueManager = FindObjectOfType<DialogueManager>();
	}

	void Update () {
		canMove = !dialogueManager.dialogueActive;
		if (moving && canMove) {
			timeToMoveCounter -= Time.deltaTime;
			rigidbody.velocity = moveDirection;
			if (timeToMoveCounter < 0) {
				moving = false;
				timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
			}
		} else {
			timeBetweenMoveCounter -= Time.deltaTime;
			rigidbody.velocity = Vector2.zero;
			if (timeBetweenMoveCounter < 0f) {
				moving = true;
				timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
				float randomX = Random.Range(-1f, 1f) * moveSpeed;
				float randomY = Random.Range(-1f, 1f) * moveSpeed;
				moveDirection = new Vector3(randomX, randomY, 0f);
			}
		}
		// if (reloading) {
			// waitToReload -= Time.deltaTime;
			// if (waitToReload < 0) {
			// 	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			// 	player.SetActive(true);
			// }
		// }
	}
}

