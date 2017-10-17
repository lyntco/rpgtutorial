using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject followTarget;
	public float moveSpeed;
	private Vector3 targetPosition;
	private static bool cameraExists;
	public BoxCollider2D boundingBox;
	private Vector3 minBounds;
	private Vector3 maxBounds;

	private Camera camera;
	private float halfHeight;
	private float halfWidth;

	void Start () {
		if (!cameraExists) {
			cameraExists = true;
			DontDestroyOnLoad(transform.gameObject);
		} else {
			Destroy(gameObject);
		}
		minBounds = boundingBox.bounds.min;
		maxBounds = boundingBox.bounds.max;
		camera = GetComponent<Camera>();
		halfHeight = camera.orthographicSize;
		halfWidth = halfHeight * Screen.width / Screen.height;
	}

	void Update () {
		Vector3 targetPosition = followTarget.transform.position;
		targetPosition = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
		if (boundingBox != null) {
			float clampedX = Mathf.Clamp(transform.position.x,  minBounds.x + halfWidth, maxBounds.x - halfWidth);
			float clampedY = Mathf.Clamp(transform.position.y,  minBounds.y + halfHeight, maxBounds.y - halfHeight);
			transform.position = new Vector3(clampedX, clampedY, transform.position.z);
		}
	}

	public void SetBounds(BoxCollider2D newBounds) {
		boundingBox = newBounds;
		minBounds = boundingBox.bounds.min;
		maxBounds = boundingBox.bounds.max;
	}
}
