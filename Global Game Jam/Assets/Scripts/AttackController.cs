using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : BaseAttackController
{
	public float AttackCooldownTimeSeconds;

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			if (Time.time >= m_timeOfNextAllowedAttack && !AttackObject.activeSelf)
			{
				m_timeOfNextAllowedAttack = Time.time + AttackCooldownTimeSeconds;
				AttackObject.SetActive(true);
				StartCoroutine("Attack");
			}
		}
	}

	private float m_timeOfNextAllowedAttack = 0;
}
