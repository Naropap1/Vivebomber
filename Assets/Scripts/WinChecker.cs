using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.childCount <= 0)
        {
            // GAME OVER YOU WIN!
            SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
        }
	}
}
