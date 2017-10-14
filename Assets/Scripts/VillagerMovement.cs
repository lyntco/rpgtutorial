using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour {
	public float moveSpeed;
	private Vector2 minMovePoint;
	private Vector2 maxMovePoint;
	private Rigidbody2D myRigidbody;

	public bool moving;
	public float moveTime;
	public float waitTime;
	private float moveCounter;
	private float waitCounter;
	private int moveDirection;

	public Collider2D moveZone;
	private bool hasMoveZone;

	public bool canMove;
	private DialogueManager dialogueManager;

	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		dialogueManager = FindObjectOfType<DialogueManager>();
		ChooseDirection();
		if (moveZone != null) {
			minMovePoint = moveZone.bounds.min;
			maxMovePoint = moveZone.bounds.max;
			hasMoveZone = true;
		}
		canMove = true;
	}

	void Update () {
		canMove = !dialogueManager.dialogueActive;

		if (!canMove) {
			myRigidbody.velocity = Vector2.zero;
			return;
		}

		if (moving) {
			moveCounter -= Time.deltaTime;
			if (moveCounter < 0f) {
				StopMoving();
			}
			switch (moveDirection) {
				case 0: // up
					myRigidbody.velocity = new Vector2(0, moveSpeed);
					if (hasMoveZone && transform.position.y > maxMovePoint.y) {
						StopMoving();
					}
					break;
				case 1: // right
					myRigidbody.velocity = new Vector2(moveSpeed, 0);
					if (hasMoveZone && transform.position.x > maxMovePoint.x) {
						StopMoving();
					}
					break;
				case 2: // down
					myRigidbody.velocity = new Vector2(0, -moveSpeed);
					if (hasMoveZone && transform.position.y < minMovePoint.y) {
						StopMoving();
					}
					break;
				case 3: // left
					myRigidbody.velocity = new Vector2(-moveSpeed, 0);
					if (hasMoveZone && transform.position.x < minMovePoint.x) {
						StopMoving();
					}
					break;
			}
		} else {
			waitCounter -= Time.deltaTime;
			if (waitCounter < 0f) {
				ChooseDirection();
				return;
			}
		}
	}

	public void StopMoving() {
		moving = false;
		waitCounter = waitTime;
	}

	public void ChooseDirection() {
		moveDirection = Random.Range(0, 4);
		moving = true;
		moveCounter = moveTime;
	}
}
