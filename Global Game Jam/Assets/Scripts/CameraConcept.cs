using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConcept : MonoBehaviour {
	public float Speed = 1;
	private Vector3 pos;
	private float x;
	private float y;

	void Start () {
		
	}

	void Update () {
		x = Input.GetAxis ("Horizontal") * Speed * Time.deltaTime;
		y = Input.GetAxis ("Vertical") * Speed * Time.deltaTime;
		pos = transform.position;
		pos.x += x;
		pos.y += y;
		transform.position = pos;

		//follow mouse
		Vector2 playerPos = Camera.main.WorldToViewportPoint (transform.position);
		Vector2 mousePos = (Vector2)Camera.main.ScreenToViewportPoint (Input.mousePosition);
		float angle = angleBetween (playerPos, mousePos);
		transform.rotation = Quaternion.Euler (0, 0, angle+45);
	}

	float angleBetween (Vector3 a, Vector3 b) {
		return Mathf.Atan2 (a.y-b.y, a.x-b.x)*Mathf.Rad2Deg;
	}
}