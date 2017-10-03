﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject followTarget;
	public float moveSpeed;
	private Vector3 targetPosition;
	private static bool cameraExists;

	void Start () {
		if (!cameraExists) {
			cameraExists = true;
			DontDestroyOnLoad(transform.gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	void Update () {
		Vector3 targetPosition = followTarget.transform.position;
		targetPosition = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
	}
}
