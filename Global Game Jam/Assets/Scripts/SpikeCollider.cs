using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeCollider : MonoBehaviour
{
	public string[] UnharmedTags;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == transform.parent.gameObject)
		{
			return;
		}

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
			if (other.gameObject.CompareTag("Player"))
			{
				SceneManager.LoadScene(0);
			}
			else
			{
				Destroy(other.gameObject);
			}
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
			if (collision.gameObject.CompareTag("Player"))
			{
				SceneManager.LoadScene(0);
			}
			else
			{
				Destroy(collision.gameObject);
			}
		}
	}
}
