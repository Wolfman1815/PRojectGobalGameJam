using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
	public GameObject BarrierObject;

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			if (!m_active)
			{
				BarrierObject.SetActive(true);
				m_active = true;
				StartCoroutine("Defend");
			}
		}
	}

	private IEnumerator Defend()
	{
		var initialScale = BarrierObject.transform.localScale;
		var targetScale = new Vector3(1.2f, 1.2f);
		yield return ScaleOverTime(targetScale, 0.06f);

		yield return new WaitForSeconds(0.5f);

		yield return ScaleOverTime(initialScale, 0.06f);
		m_active = false;
		BarrierObject.SetActive(false);
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
}
