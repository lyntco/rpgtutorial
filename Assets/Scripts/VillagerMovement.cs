using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour {
	public float moveSpeed;
	private Vector2 minMovePoint;
	private Vector2 maxMovePoint;
	private Rigidbody2D rigidbody;

	public bool moving;
	public float moveTime;
	public float waitTime;
	private float moveCounter;
	private float waitCounter;
	private int moveDirection;

	public Collider2D moveZone;
	private bool hasMoveZone;

	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		ChooseDirection();
		if (moveZone != null) {
			minMovePoint = moveZone.bounds.min;
			maxMovePoint = moveZone.bounds.max;
			hasMoveZone = true;
		}
	}

	void Update () {
		if (moving) {
			moveCounter -= Time.deltaTime;
			if (moveCounter < 0) {
				StopMoving();
			}
			switch (moveDirection) {
				case 0:
					rigidbody.velocity = new Vector2(0, moveSpeed);
					if (hasMoveZone && transform.position.y > maxMovePoint.y) {
						StopMoving();
					}
					break;
				case 1:
					rigidbody.velocity = new Vector2(moveSpeed, 0);
					if (hasMoveZone && transform.position.x > maxMovePoint.x) {
						StopMoving();
					}
					break;
				case 2:
					rigidbody.velocity = new Vector2(0, -moveSpeed);
					if (hasMoveZone && transform.position.y < minMovePoint.y) {
						StopMoving();
					}
					break;
				case 3:
					rigidbody.velocity = new Vector2(-moveSpeed, 0);
					if (hasMoveZone && transform.position.x < minMovePoint.x) {
						StopMoving();
					}
					break;
				default:
					break;
			}
		} else {
			waitCounter -= Time.deltaTime;
			if (waitCounter < 0) {
				ChooseDirection();
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
