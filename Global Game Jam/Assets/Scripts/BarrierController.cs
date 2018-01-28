using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
	public GameObject BarrierObject;
	public float BarrierCooldownTimeSeconds;

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			if (Time.time >= m_timeOfNextAllowedBarrier && !m_active)
			{
				m_timeOfNextAllowedBarrier = Time.time + BarrierCooldownTimeSeconds;
				BarrierObject.SetActive(true);
				m_active = true;
				StartCoroutine("Defend");
			}
		}
	}

	private IEnumerator Defend()
	{
		BlowAwayNearbyEnemies();

		var initialScale = BarrierObject.transform.localScale;
		var targetScale = new Vector3(1.2f, 1.2f);
		yield return ScaleOverTime(targetScale, 0.06f);

		yield return new WaitForSeconds(0.5f);

		yield return ScaleOverTime(initialScale, 0.06f);
		m_active = false;
		BarrierObject.SetActive(false);
	}

	private void BlowAwayNearbyEnemies()
	{
		Vector3 explosionPosition = transform.position;
		var explosionRadius = 2.8f;

		var colliders = Physics2D.OverlapCircleAll(explosionPosition, explosionRadius);

		foreach (Collider2D hitCollider in colliders)
		{
			var hitRigidBody = hitCollider.GetComponent<Rigidbody2D>();

			if (hitRigidBody != null)
			{
				var force = hitRigidBody.transform.position - explosionPosition;
				if (force.magnitude >= explosionRadius)
				{
					continue;
				}
				
				hitRigidBody.AddForce(force.normalized * 12, ForceMode2D.Impulse);
			}
		}
	}

	private IEnumerator ScaleOverTime(Vector3 targetScale, float durationSeconds)
	{
		var initialScale = BarrierObject.transform.localScale;
		float elapsedTime = 0;

		while (elapsedTime < durationSeconds)
		{
			elapsedTime += Time.deltaTime;
			if (elapsedTime >= durationSeconds)
			{
				BarrierObject.transform.localScale = targetScale;
			}
			else
			{
				BarrierObject.transform.localScale = initialScale + (targetScale - initialScale) * elapsedTime / durationSeconds;
			}

			yield return null;
		}
	}

	private bool m_active;
	private float m_timeOfNextAllowedBarrier = 0;
}
