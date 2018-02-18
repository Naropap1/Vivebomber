using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour {

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.forward; // zero
    private Vector3 realMoveDirection = Vector3.zero;

    private int xAmnt = 0, yAmnt = 0, zAmnt = 1;
    private float timeStuck = 3f, timeStuck2 = .5f;
    private bool isStopCol = false;
    private Vector3 myPos = Vector3.zero;
    private Vector3 myNewPos = Vector3.one;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        timeStuck -= Time.deltaTime;
        timeStuck2 -= Time.deltaTime;

        myPos = transform.position;
        if (timeStuck2 < 1)
        {
            if (myPos == myNewPos)
            {
                isStopCol = !isStopCol;
            }
            myNewPos = myPos;
        }

        if (timeStuck < 0)
        {
            timeStuck = 3f;
            int num = Random.Range(0, 3);
            //Debug.Log(num);
            if (num == 0)
            {
                if (moveDirection == Vector3.back)
                {
                    moveDirection = Vector3.right;
                }
                else
                {
                    moveDirection = Vector3.back;
                }
            }
            else if (num == 1)
            {
                if (moveDirection == Vector3.forward)
                {
                    moveDirection = Vector3.left;
                }
                else
                {
                    moveDirection = Vector3.forward;
                }
            }
            else if (num == 2)
            {
                if (moveDirection == Vector3.left)
                {
                    moveDirection = Vector3.right;
                }
                else
                {
                    moveDirection = Vector3.left;
                }
            }
            else
            {
                if (moveDirection == Vector3.right)
                {
                    moveDirection = Vector3.left;
                }
                else
                {
                    moveDirection = Vector3.right;
                }
            }
        }
            CharacterController controller = GetComponent<CharacterController>();
            if (controller.isGrounded)
            {
                //moveDirection = Vector3.forward;// new Vector3(transform.position.x + xAmnt, transform.position.y + yAmnt, transform.position.z + zAmnt);
               
                //controller.transform.localRotation = Quaternion.Euler(moveDirection);
            
                realMoveDirection = moveDirection;
                realMoveDirection = transform.TransformDirection(realMoveDirection);
                realMoveDirection *= speed;
                if (Input.GetButton("Jump"))
                    realMoveDirection.y = jumpSpeed;

            }
            realMoveDirection.y -= gravity * Time.deltaTime;
            controller.Move(realMoveDirection * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision) {
            if (!isStopCol) { }
            int num = Random.Range(0, 3);
            //Debug.Log(num);
            if (num == 0)
            {
                if (moveDirection == Vector3.back)
                {
                    moveDirection = Vector3.right;
                }
                else
                {
                    moveDirection = Vector3.back;
                }
            }
            else if (num == 1)
            {
                if (moveDirection == Vector3.forward)
                {
                    moveDirection = Vector3.left;
                }
                else
                {
                    moveDirection = Vector3.forward;
                }
            } else if (num == 2)
            {
                if (moveDirection == Vector3.left)
                {
                    moveDirection = Vector3.right;
                }
                else
                {
                    moveDirection = Vector3.left;
                }
            }
            else
            {
                if (moveDirection == Vector3.right)
                {
                    moveDirection = Vector3.left;
                }
                else
                {
                    moveDirection = Vector3.right;
                }
            }
        }
    }

