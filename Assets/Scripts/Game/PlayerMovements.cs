using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    void Start()
    {
        force = 500f;
    }

    void Update()
    {
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, force * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-force * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -force * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(force * Time.deltaTime, 0, 0);
        }
    }
}
