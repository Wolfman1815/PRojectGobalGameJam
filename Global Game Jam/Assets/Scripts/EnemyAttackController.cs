using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : BaseAttackController
{
	void Start()
	{
		StartCoroutine("PeriodicAttack");
	}

	IEnumerator PeriodicAttack()
	{
		while(true)
		{
			yield return new WaitForSeconds(3);

			AttackObject.SetActive(true);
			StartCoroutine("Attack");
		}
	}
}
