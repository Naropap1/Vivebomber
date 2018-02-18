using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Script : MonoBehaviour {


    public Material redMat;
    private bool doStart = false;
    private float timeLeft = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (doStart)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Destroy(gameObject);
            }
        }
	}

    public void activateBlock()
    {
        GetComponent<MeshRenderer>().material = redMat;
        doStart = true;
    }
}
