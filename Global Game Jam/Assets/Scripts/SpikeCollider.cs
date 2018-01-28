﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollider : MonoBehaviour
{
	public string UnharmedTag;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.gameObject.CompareTag(UnharmedTag))
		{
			var barrierController = other.gameObject.GetComponent<BarrierController>();

			if (barrierController == null || !barrierController.BarrierObject.activeSelf)
			{
				Destroy(other.gameObject);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (!collision.gameObject.CompareTag(UnharmedTag))
		{
			Destroy(collision.gameObject);
		}
	}
}
