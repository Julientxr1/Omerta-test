using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using Photon.Pun;


public class Cameramouvement : MonoBehaviourPunCallbacks
{
 public float speed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Transform playerCameraParent;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;



    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;
    public Animator animator;

    [HideInInspector]
    public bool canMove = true;

    public override void OnEnable()
    {
        if (photonView.IsMine)
        {
            characterController = GetComponent<CharacterController>();
            rotation.y = transform.eulerAngles.y;
        }
    }


    void Update()
    {
        if (photonView.IsMine)
        {
            if (characterController.isGrounded)
            {
                // We are grounded, so recalculate move direction based on axes
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                Vector3 right = transform.TransformDirection(Vector3.right);
                float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
                float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
                moveDirection = (forward * curSpeedX) + (right * curSpeedY);
                float inputpress = Mathf.Clamp01(moveDirection.magnitude);
          
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    inputpress *= 2;
                

                }
                animator.SetFloat("speed",inputpress/2,0.05f,Time.deltaTime);

                if (Input.GetButton("Jump") && canMove)
                {
                    moveDirection.y = jumpSpeed;
                }
            }
            // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
            // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
            // as an acceleration (ms^-2)
            moveDirection.y -= gravity * Time.deltaTime;

            // Move the controller
            characterController.Move(moveDirection * Time.deltaTime);

            // Player and Camera rotation
            if (canMove)
            {
                rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
                rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
                playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
                transform.eulerAngles = new Vector2(0, rotation.y);
            }
        }
    }
}
