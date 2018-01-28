using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
	public GameObject AttackObject;

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			if (!m_active)
			{
				AttackObject.SetActive(true);
				m_active = true;
				StartCoroutine("Attack");
			}
		}
	}

	private IEnumerator Attack()
	{
		ZoomForward();

		var initialPosition = AttackObject.transform.position;
		var targetRelativePosition = new Vector3(0, 1);
		yield return MoveOverTime(targetRelativePosition, 0.06f);

		yield return new WaitForSeconds(0.3f);

		yield return MoveOverTime(Vector3.zero, 0.06f);
		m_active = false;
		AttackObject.SetActive(false);
	}

	void ZoomForward()
	{
		var rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(-180, -180, -33));
		gameObject.GetComponent<Rigidbody2D>().AddForce(rotation * new Vector3(20, 0), ForceMode2D.Impulse);
	}

	private IEnumerator MoveOverTime(Vector3 targetRelativePosition, float durationSeconds)
	{
		float elapsedTime = 0;

		while (elapsedTime < durationSeconds)
		{
			var currentRotation = AttackObject.transform.localRotation;
			elapsedTime += Time.deltaTime;
			if (elapsedTime >= durationSeconds)
			{
				AttackObject.transform.localPosition = currentRotation * targetRelativePosition;
			}
			else
			{
				AttackObject.transform.localPosition = currentRotation * targetRelativePosition * elapsedTime / durationSeconds;
			}

			yield return null;
		}
	}

	private bool m_active;
}
