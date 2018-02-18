using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharMove : MonoBehaviour{

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;

    public GameObject bomb;

    private Vector3 moveDirection = Vector3.zero;


    // Use this for initialization
    void Start(){

    }

    void Update(){
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded){
            moveDirection = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        yaw += speedH * Input.GetAxis("Mouse X");
       // pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(0, yaw, 0.0f);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bomb, new Vector3(transform.position.x, bomb.transform.position.y, transform.position.z), bomb.transform.rotation);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        SceneManager.LoadScene("LoseScene", LoadSceneMode.Single);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("enemy"))
        {
            SceneManager.LoadScene("LoseScene", LoadSceneMode.Single);
        }
    }

}
