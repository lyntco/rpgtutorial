using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {
	private PlayerController player;
	private CameraController camera;
	public Vector2 startDirection;

	void Start () {
		Vector3 currentPosition = transform.position;
		player = FindObjectOfType<PlayerController>();
		player.transform.position = currentPosition;
		player.lastMove = startDirection;
		camera = FindObjectOfType<CameraController>();
		camera.transform.position = new Vector3(currentPosition.x, currentPosition.y, camera.transform.position.z);
	}

	void Update () {

	}
}
