

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alternativemove : MonoBehaviour
{
    public CharacterController Controller;
    public Animator Animator;
    [Header("Mouvement")] 
    public float speed = 1f;
    public float gravity = -9.10f;
    public float jumpHeight = 1f;
    [Header("Ground Check")] 
    public Transform ground_check;
    public float ground_distance=0.4f;
    public LayerMask ground_mask;

    private Vector3 direction;
    private bool isGround;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics.CheckSphere(ground_check.position, ground_distance, ground_mask);
        if (isGround && direction.y<0)
        {
            direction.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Animator.SetFloat("foward",z);
        Animator.SetFloat("strafe",x);
        Vector3 movement = transform.right * x + transform.forward * z;

        Controller.Move(movement * (speed * Time.deltaTime));
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 3f;
            Animator.SetBool("run",true);
        }
        else
        {
            Animator.SetBool("run",false);
        }
        if (Input.GetButtonDown("Jump") && isGround)
        {
            direction.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            
        }

        if (isGround)
        {
            Animator.SetBool("jump", false);
        }
        else
        {
            Animator.SetBool("jump",true);
        }

        direction.y += gravity * Time.deltaTime;
        Controller.Move(direction * Time.deltaTime);
    }
}
