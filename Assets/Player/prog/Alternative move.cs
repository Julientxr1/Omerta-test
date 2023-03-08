

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


    private void Start()
    {
        Controller = GetComponent<CharacterController>();
        orginal = Controller.stepOffset;
    }

    private void Update()
    {
        float horizontalinput = Input.GetAxis("Horizontal");
        float verticalinput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalinput, 0, verticalinput);
        float magnitude = Mathf.Clamp01(direction.magnitude) * speed; 
        direction.Normalize();
        Controller.SimpleMove(direction * magnitude);
        gravity += Physics.gravity.y * Time.deltaTime;
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

        if (direction!= Vector3.zero)
        {
            Quaternion rota = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = 
                Quaternion.RotateTowards(transform.rotation, rota, rotaspeed * Time.deltaTime);
        }
    }
}
