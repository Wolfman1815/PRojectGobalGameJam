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
		if (Vector3.Distance (transform.position, player.transform.position) < chaseRange) {
			target = player.transform;
		} else {
			target = FindClosestEnemy().transform;
		}
		float distanceToTarget = Vector3.Distance(transform.position, target.position);
		if(distanceToTarget < chaseRange) {
			Vector3 targetDir = target.position - transform.position;
			float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
			gameObject.GetComponent<Rigidbody2D> ().AddForce (transform.rotation * Vector3.up * Time.deltaTime * speed, ForceMode2D.Force);
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
