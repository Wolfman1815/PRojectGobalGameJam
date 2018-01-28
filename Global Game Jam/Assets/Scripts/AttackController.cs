using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : BaseAttackController
{
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			if (!AttackObject.activeSelf)
			{
				AttackObject.SetActive(true);
				StartCoroutine("Attack");
			}
		}
	}
}
