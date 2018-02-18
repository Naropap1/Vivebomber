using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour {


	public GameObject fire_left, fire_right, fire_up, fire_down;
	
	private float timeLeft = 4.0f;
	private float timeToDestroy = 6.0f;
	
	private float fireTime = 0f;
    private Vector3 startPosition;
    private Vector3 target;
    float timeToReachTarget = 0.5f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		timeToDestroy -= Time.deltaTime;
        if(timeLeft < 0){
			// Right fire
			 Vector3 right = Vector3.right  + new Vector3(0, .9f, 0);

            RaycastHit hit = new RaycastHit();
            Debug.DrawRay(transform.position, right, Color.green);
			 if (!Physics.Raycast(transform.position, right, out hit, 4f)){
				startPosition = transform.position;
				target = new Vector3(transform.position.x + 2.7f, transform.position.y, transform.position.z);
				fireTime += Time.deltaTime/timeToReachTarget;
				fire_left.transform.position = Vector3.Lerp(startPosition, target, fireTime);
            }
            else
            {
                if (hit.collider != null)
                {
                    startPosition = transform.position;
                    target = new Vector3(hit.collider.gameObject.transform.position.x, transform.position.y, transform.position.z);
                    fireTime += Time.deltaTime / timeToReachTarget;
                    fire_left.transform.position = Vector3.Lerp(startPosition, target, fireTime);

                    if (hit.collider.gameObject.tag.Contains("Remov")){
                        hit.collider.gameObject.GetComponent<Block_Script>().activateBlock();
                    }else if (hit.collider.gameObject.tag.Contains("Enem"))
                    {
                       
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
			
			// Up fire
			Vector3 forward = Vector3.forward + new Vector3(0, .9f, 0);

			Debug.DrawRay(transform.position, forward, Color.green);
			 if (!Physics.Raycast(transform.position, forward, out hit, 4f)){
                startPosition = transform.position;
				target = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2.7f);
				fireTime += Time.deltaTime/timeToReachTarget;
				fire_right.transform.position = Vector3.Lerp(startPosition, target, fireTime);
            }
            else
            {
                if (hit.collider != null)
                {
                    startPosition = transform.position;
                    target = new Vector3(transform.position.x, transform.position.y, hit.collider.gameObject.transform.position.z);
                    fireTime += Time.deltaTime / timeToReachTarget;
                    fire_right.transform.position = Vector3.Lerp(startPosition, target, fireTime);

                    if (hit.collider.gameObject.tag.Contains("Remov"))
                    {
                        hit.collider.gameObject.GetComponent<Block_Script>().activateBlock();
                    }
                    else if (hit.collider.gameObject.tag.Contains("Enem"))
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
			
			// Left fire
			Vector3 left = Vector3.left + new Vector3(0, .9f, 0);

			Debug.DrawRay(transform.position, left, Color.green);
			 if (!Physics.Raycast(transform.position, left, out hit, 4f)){
                startPosition = transform.position;
				target = new Vector3(transform.position.x - 2.7f, transform.position.y, transform.position.z);
				fireTime += Time.deltaTime/timeToReachTarget;
				fire_up.transform.position = Vector3.Lerp(startPosition, target, fireTime);
            }
            else
            {
                if (hit.collider != null)
                {
                    startPosition = transform.position;
                    target = new Vector3(hit.collider.gameObject.transform.position.x, transform.position.y, transform.position.z);
                    fireTime += Time.deltaTime / timeToReachTarget;
                    fire_up.transform.position = Vector3.Lerp(startPosition, target, fireTime);

                    if (hit.collider.gameObject.tag.Contains("Remov"))
                    {
                        hit.collider.gameObject.GetComponent<Block_Script>().activateBlock();
                    }
                    else if (hit.collider.gameObject.tag.Contains("Enem"))
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
			
			// Back fire
			Vector3 back = Vector3.back + new Vector3(0, .9f, 0);
			
			Debug.DrawRay(transform.position, back, Color.green);
			 if (!Physics.Raycast(transform.position, back, out hit, 4f)){
                startPosition = transform.position;
			target = new Vector3(transform.position.x, transform.position.y, transform.position.z - +2.7f);
			fireTime += Time.deltaTime/timeToReachTarget;
			fire_down.transform.position = Vector3.Lerp(startPosition, target, fireTime);
            }
            else
            {
                if (hit.collider != null)
                {
                    startPosition = transform.position;
                    target = new Vector3(transform.position.x, transform.position.y, hit.collider.gameObject.transform.position.z);
                    fireTime += Time.deltaTime / timeToReachTarget;
                    fire_down.transform.position = Vector3.Lerp(startPosition, target, fireTime);

                    if (hit.collider.gameObject.tag.Contains("Remov"))
                    {
                        hit.collider.gameObject.GetComponent<Block_Script>().activateBlock();
                    }
                    else if (hit.collider.gameObject.tag.Contains("Enem"))
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
		
		if (timeToDestroy < 0){
			Destroy(gameObject);
		}
	}
}
