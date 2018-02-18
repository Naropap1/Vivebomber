using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMove : MonoBehaviour {

	public GameObject bomb;
	public GameObject camera;
	public float speed = 3F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
	private bool isHeld = false;
    private SteamVR_TrackedObject trackedObj;
    // 2
    private SteamVR_Controller.Device Controller{
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake(){
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// 1
		if (Controller.GetAxis() != Vector2.zero){
			//Debug.Log(gameObject.name + Controller.GetAxis());
		}

		// 2
		if (Controller.GetHairTriggerDown()){
			Instantiate(bomb, new Vector3(transform.parent.parent.transform.position.x, bomb.transform.position.y, transform.parent.parent.transform.position.z), bomb.transform.rotation);//new Quaternion(0, 0, 0, 0));//Quaternion.identity);
			//Debug.Log(gameObject.name + " Trigger Press");
			
        }

		// 3
		if (Controller.GetHairTriggerUp()){

			//Debug.Log(gameObject.name + " Trigger Release");
		}

		// 4
		if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip)){
			//Debug.Log(gameObject.name + " Grip Press");
		}

		// 5
		if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip)){
			//Debug.Log(gameObject.name + " Grip Release");
		}
		
		//if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad)){
		if(SteamVR_Controller.Input((int)trackedObj.index).GetAxis().x != 0 || SteamVR_Controller.Input((int)trackedObj.index).GetAxis().y != 0){
			//Debug.Log(gameObject.name + " Touchpad");
			Vector2 touchpad = (SteamVR_Controller.Input((int)trackedObj.index).GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));
			CharacterController controller = transform.parent.parent.GetComponent<CharacterController>();
			if (controller.isGrounded){
				//Vector3.forward;//new Vector3(camera.transform.rotation.x, 0, camera.transform.rotation.y);
				/*if (touchpad.y > 0.7f){
					//print("Moving Up");
					moveDirection = camera.transform.rotation * Vector3.forward;
				}else if (touchpad.y < -0.7f){
					//print("Moving Down");
					moveDirection = camera.transform.rotation * Vector3.back;
				}else if (touchpad.x > 0.7f){
					//print("Moving Right");
					moveDirection = camera.transform.rotation * Vector3.right;
				}else if (touchpad.x < -0.7f){
					//print("Moving left");
					moveDirection = camera.transform.rotation * Vector3.left;
				}*/
				moveDirection = camera.transform.right*touchpad.x + camera.transform.forward*touchpad.y;//.rotation * touchpad;
				moveDirection *= speed;
				
			}
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);
			
			

			
		}
	}
}

