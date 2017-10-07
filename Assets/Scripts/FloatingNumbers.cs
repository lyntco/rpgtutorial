using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingNumbers : MonoBehaviour {
	public float moveSpeed;
	public int damageNumber;
	public Text displayNumber;
	void Start () {
	}

	void Update () {
		displayNumber.text = "" + damageNumber;
		float yValue = transform.position.y + (moveSpeed * Time.deltaTime);
		print(yValue);
		transform.position = new Vector3(transform.position.x, yValue, transform.position.z);
	}
}
