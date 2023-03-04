using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermouvement : MonoBehaviour
{
    [SerializeField] private float Movespeed;
    [SerializeField] private float Walkspeed;
    [SerializeField] private float Runspeed;
    [SerializeField] private bool IsGrounded;
    [SerializeField] private float Groundcheck;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    [SerializeField] private float JumpHeight;
    
    

    private Vector3 Direction;
    private Vector3 Velocity;
    private CharacterController controller;
    private Animator anim;
    // Update is called once per frame
    private void Start()
    {
        
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        IsGrounded = Physics.CheckSphere(transform.position, Groundcheck, groundMask);
        if (IsGrounded && Velocity.y<0)
        {
            Velocity.y = -2f;
        }
        float moveZ = Input.GetAxis("Vertical");
        Direction = new Vector3(0, 1, moveZ);
        Direction = transform.TransformDirection(Direction);

        if (IsGrounded)
        {
            if (Direction != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if (Direction != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (Direction==Vector3.zero)
            {
                Idle();
            }
            Direction *= Movespeed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        
        controller.Move(Direction * Time.deltaTime);
        Velocity.y += gravity * Time.deltaTime;
        controller.Move(Velocity * Time.deltaTime);
    }

    private void Idle()
    {
        anim.SetFloat("Blend",0,0.1f,Time.deltaTime);
    }
    private void Walk()
    {
        Movespeed = Walkspeed;
        anim.SetFloat("Blend",0.5f,0.1f,Time.deltaTime);
    }
    private void Run()
    {
        Movespeed = Runspeed;
        anim.SetFloat("Blend",1,0.1f,Time.deltaTime);
    }

    private void Jump()
    {
        Velocity.y = Mathf.Sqrt(JumpHeight * -2 * gravity);
    }
}
