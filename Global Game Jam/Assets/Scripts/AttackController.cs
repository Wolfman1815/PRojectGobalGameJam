using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
	public GameObject AttackObject;

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (!m_active)
			{
				m_active = true;
				StartCoroutine("Attack");
			}
		}
	}

	private IEnumerator Attack()
	{
		var initialPosition = AttackObject.transform.position;
		var targetPosition = initialPosition + AttackObject.transform.rotation * new Vector3(0, 2.9f);
		yield return MoveOverTime(targetPosition, 0.06f);

		yield return new WaitForSeconds(0.3f);

		yield return MoveOverTime(initialPosition, 0.06f);
		m_active = false;
	}

	private IEnumerator MoveOverTime(Vector3 targetPosition, float durationSeconds)
	{
		var initialPosition = AttackObject.transform.position;
		float elapsedTime = 0;

		while (elapsedTime < durationSeconds)
		{
			elapsedTime += Time.deltaTime;
			if (elapsedTime >= durationSeconds)
			{
				AttackObject.transform.position = targetPosition;
			}
			else
			{
				AttackObject.transform.position = initialPosition + (targetPosition - initialPosition) * elapsedTime / durationSeconds;
			}

			yield return null;
		}
	}

	private bool m_active;
}
