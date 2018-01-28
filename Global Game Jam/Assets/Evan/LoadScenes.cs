using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour {
    private object levelToLoad;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Application.loadedLevel(levelToLoad);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
