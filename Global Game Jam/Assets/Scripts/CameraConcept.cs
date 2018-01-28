using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConcept : MonoBehaviour {
	public float Speed;

	void FixedUpdate () {
		float x = Input.GetAxis ("Horizontal") * Speed * Time.deltaTime;
		float y = Input.GetAxis ("Vertical") * Speed * Time.deltaTime;

		gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(x, y), ForceMode2D.Force);

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