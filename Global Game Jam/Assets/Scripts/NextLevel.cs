using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
	void Update()
	{
		var livingEnemies = GameObject.FindGameObjectsWithTag("Enemy");
		if (livingEnemies.Length == 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
