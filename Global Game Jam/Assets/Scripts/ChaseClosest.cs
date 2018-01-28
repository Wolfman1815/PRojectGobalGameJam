using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseClosest : MonoBehaviour {
	Transform target;
	public float chaseRange;
	public float speed;
	public GameObject player;

	void Start () {
		
	}

	void Update () {
		target = FindClosestEnemy ().transform;
		if (player != null) {
			float distanceToPlayer = Vector3.Distance (transform.position, player.transform.position);
			float distanceToTarget = Vector3.Distance (transform.position, target.position);
			if (distanceToPlayer < distanceToTarget) {
				Vector3 targetDir = player.transform.position - transform.position;
				float angle = Mathf.Atan2 (targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
				//Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
				Quaternion q = Quaternion.Euler (0, 0, angle - 45);
				transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 180);
				gameObject.GetComponent<Rigidbody2D> ().AddForce (transform.rotation * Vector3.up * Time.deltaTime * speed, ForceMode2D.Force);
			} else {
				Vector3 targetDir = target.position - transform.position;
				float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
				//Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
				Quaternion q = Quaternion.Euler(0, 0, angle-45);
				transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
				gameObject.GetComponent<Rigidbody2D> ().AddForce (transform.rotation * Vector3.up * Time.deltaTime * speed, ForceMode2D.Force);
			}
		} else {
			//GAME OVER
			//Vector3 targetDir = target.position - transform.position;
			//float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
			//Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			//Quaternion q = Quaternion.Euler(0, 0, angle-45);
			//transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
			//gameObject.GetComponent<Rigidbody2D> ().AddForce (transform.rotation * Vector3.up * Time.deltaTime * speed, ForceMode2D.Force);
		}
	}

	GameObject FindClosestEnemy() {
		GameObject closest = player;
		GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos) {
			if(go == gameObject) {
				continue;
			}
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance){
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}
}
