using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float moveSpeed;
	public float diagonalMoveModifier;
	public Vector2 lastMove;
	public string startPoint;

	private float currentMoveSpeed;
	private Animator animator;
	private bool playerMoving;
	private Rigidbody2D myRigidBody;
	private static bool playerExists;
	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;

	public bool canMove;

	void Start () {
		animator = GetComponent<Animator>();
		myRigidBody = GetComponent<Rigidbody2D>();
		if (!playerExists) {
			playerExists = true;
			canMove = true;
			DontDestroyOnLoad(transform.gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	void Update () {
		playerMoving = false;
		if (!canMove) {
			myRigidBody.velocity = Vector2.zero;
			return;
		}

		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");

		if (!attacking) {
			if (moveX > 0.1f || moveX < -0.1f) {
				// transform.Translate(new Vector3(moveX * moveSpeed * Time.deltaTime, 0f, 0f));
				myRigidBody.velocity = new Vector2(moveX * currentMoveSpeed, myRigidBody.velocity.y);
				playerMoving = true;
				lastMove = new Vector2(moveX, 0f);
			}
			if (moveY > 0.1f || moveY < -0.1f) {
				// transform.Translate(new Vector3(0f, moveY * moveSpeed * Time.deltaTime, 0f));
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, moveY * currentMoveSpeed);
				playerMoving = true;
				lastMove = new Vector2(0f, moveY);
			}

			if (moveX < 0.1f && moveX > -0.1f) {
				myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
			}
			if (moveY < 0.1f && moveY > -0.1f) {
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);
			}
			if (Input.GetKeyDown(KeyCode.X)) {
				attackTimeCounter = attackTime;
				attacking = true;
				// myRigidBody.velocity = Vector2.zero;
				animator.SetBool("PlayerAttacking", true);
			}

			if (Mathf.Abs(moveX) > 0.1f && Mathf.Abs(moveY) > 0.1f) {
				currentMoveSpeed = moveSpeed * diagonalMoveModifier;
			} else {
				currentMoveSpeed = moveSpeed;
			}
		}

		if (attackTimeCounter >= 0) {
			attackTimeCounter -= Time.deltaTime;
			if (attackTimeCounter <= 0) {
				attacking = false;
				animator.SetBool("PlayerAttacking", false);
			}
		}


		animator.SetFloat("MoveX", moveX);
		animator.SetFloat("MoveY", moveY);
		animator.SetBool("PlayerMoving", playerMoving);
		animator.SetFloat("LastMoveX", lastMove.x);
		animator.SetFloat("LastMoveY", lastMove.y);
	}
}
