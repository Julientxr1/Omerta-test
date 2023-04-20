using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletprojectile : MonoBehaviour
{
    public float life = 3f;
    
    void Awake()
    {
        Destroy(gameObject,life);
        

    }
    

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
