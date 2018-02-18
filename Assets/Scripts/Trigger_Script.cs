using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Script : MonoBehaviour {

	public GameObject bomb;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other) {
        //Destroy(other.gameObject);
		try{
			//Debug.Log(other.gameObject.name);
			//BombScript bs = other.gameObject.GetComponent<BombScript>();
			if (other.gameObject.name.Contains("bomb_prefab")){
				other.gameObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
			}
		}catch (UnityException ex){
			Debug.Log(ex);
		}
    }
}
