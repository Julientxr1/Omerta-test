using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    private float buletspeed = 2000;
    

    public GameObject bullet;
  

    private AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource=GetComponent<AudioSource>();
    }

    void fire()
    {
        GameObject tempbullet=Instantiate(bullet,transform.position,transform.rotation) as GameObject;
        Rigidbody tempRigidbodybullet = tempbullet.GetComponent<Rigidbody>();
        tempRigidbodybullet.AddForce(tempRigidbodybullet.transform.forward* buletspeed);
        tempRigidbodybullet.AddForce(tempRigidbodybullet.transform.up * -500 );
        Destroy(tempbullet , 0.5f);
        AudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fire();
        }
    }

    
}
