using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollider : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		bool isPlayer = gameObject.CompareTag("Player");
		bool otherIsPlayer = other.gameObject.CompareTag("Player");

		if (isPlayer != otherIsPlayer)
		{
			Destroy(other.gameObject);
		}
	}
}
