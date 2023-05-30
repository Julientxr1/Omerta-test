 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletprojectile : MonoBehaviour
{
    public float life = 100f;

    private void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }

        
    }
}
