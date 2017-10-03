using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float moveSpeed;
	private Animator animator;
	private bool playerMoving;
	private Rigidbody2D myRigidBody;
	private Vector2 lastMove;
	private static bool playerExists;

	void Start () {
		animator = GetComponent<Animator>();
		myRigidBody = GetComponent<Rigidbody2D>();
		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad(transform.gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	void Update () {
		playerMoving = false;
		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");
		if (moveX > 0.1f || moveX < -0.1f) {
			// transform.Translate(new Vector3(moveX * moveSpeed * Time.deltaTime, 0f, 0f));
			myRigidBody.velocity = new Vector2(moveX * moveSpeed, myRigidBody.velocity.y);
			playerMoving = true;
			lastMove = new Vector2(moveX, 0f);
		}
		if (moveY > 0.1f || moveY < -0.1f) {
			// transform.Translate(new Vector3(0f, moveY * moveSpeed * Time.deltaTime, 0f));
			myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, moveY * moveSpeed);
			playerMoving = true;
			lastMove = new Vector2(0f, moveY);
		}

		if (moveX < 0.1f && moveX > -0.1f) {
			myRigidBody.velocity = new Vector2(0f, myRigidBody.velocity.y);
		}
		if (moveY < 0.1f && moveY > -0.1f) {
			myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, 0f);
		}
		animator.SetFloat("MoveX", moveX);
		animator.SetFloat("MoveY", moveY);
		animator.SetBool("PlayerMoving", playerMoving);
		animator.SetFloat("LastMoveX", lastMove.x);
		animator.SetFloat("LastMoveY", lastMove.y);
	}
}
