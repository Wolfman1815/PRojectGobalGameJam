using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollider : MonoBehaviour
{
	public string[] UnharmedTags;

	void OnTriggerEnter2D(Collider2D other)
	{
		var collidedObjectTag = other.gameObject.tag;
		foreach (var tag in UnharmedTags)
		{
			if (tag.Equals(collidedObjectTag))
			{
				return;
			}
		}

		var barrierController = other.gameObject.GetComponent<BarrierController>();

		if (barrierController == null || !barrierController.BarrierObject.activeSelf)
		{
			Destroy(other.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		var collidedObjectTag = collision.gameObject.tag;
		foreach (var tag in UnharmedTags)
		{
			if (tag.Equals(collidedObjectTag))
			{
				return;
			}
		}

		var barrierController = collision.gameObject.GetComponent<BarrierController>();

		if (barrierController == null || !barrierController.BarrierObject.activeSelf)
		{
			Destroy(collision.gameObject);
		}
	}
}
