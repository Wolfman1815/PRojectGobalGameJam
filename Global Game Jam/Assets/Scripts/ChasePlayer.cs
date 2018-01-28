using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour {
	Transform target;
	public float chaseRange;
	public float speed;

	void Start ()
	{
		m_player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () {
		Vector3 targetDir = m_player.transform.position - transform.position;
		float angle = Mathf.Atan2 (targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
		//Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		Quaternion q = Quaternion.Euler (0, 0, angle - 45);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 180);
		gameObject.GetComponent<Rigidbody2D> ().AddForce (transform.rotation * Vector3.up * Time.deltaTime * speed, ForceMode2D.Force);
	}

	private GameObject m_player;
}
