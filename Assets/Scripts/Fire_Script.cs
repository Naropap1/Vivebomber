using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fire_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnParticleCollision(GameObject other){
        if (other.tag.Contains("Enem"))
        {
            Destroy(other);
        }else if (other.tag.Contains("Player"))
        {
            SceneManager.LoadScene("LoseScene", LoadSceneMode.Single);
        }
    }
}
