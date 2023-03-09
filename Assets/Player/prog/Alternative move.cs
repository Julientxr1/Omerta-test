

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alternativemove : MonoBehaviour
{
    public float speed;
    public float rotaspeed;
    private CharacterController Controller;
    public float jumpspeed;
    private float gravity;
    private float orginal;
    private Animator Animator;


    private void Start()
    {
        Controller = GetComponent<CharacterController>();
        orginal = Controller.stepOffset;
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalinput = Input.GetAxis("Horizontal");
        float verticalinput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalinput, 0, verticalinput);
        float inputpress = Mathf.Clamp01(direction.magnitude);
        float magnitude =inputpress * (speed *1.2f); 
        direction.Normalize();
        Controller.SimpleMove(direction * magnitude);
        gravity += Physics.gravity.y * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            inputpress /= 2;
        }
        Animator.SetFloat("speed",inputpress,0.05f,Time.deltaTime);
        if (Controller.isGrounded)
        {
            Controller.stepOffset = orginal;
            gravity = -0.5f;
            if (Input.GetButtonDown("Jump"))
            {
                gravity = jumpspeed;
            }

        }
        else
        {
            Controller.stepOffset = 0;
        }
        
        Vector3 velocity = direction * magnitude;
        velocity.y = gravity;
        Controller.Move(velocity * Time.deltaTime);

  
    }
}
