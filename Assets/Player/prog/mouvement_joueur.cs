using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvement_joueur : MonoBehaviour
{
    public GameObject joueur;
    public bool running;
    public float verticalmove;
    public float horizontalmove;
    public Animation controller;

    private void Start()
    {
         controller =joueur.GetComponent<Animation>();
    }

    

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.LeftShift))
        {
            running = false;
        }
        else
        {
            running=true;
        }
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical") && !running)
        {
            controller.Play("Walk");
            horizontalmove = Input.GetAxis("Horizontal") * Time.deltaTime * 150;
            verticalmove = Input.GetAxis("Vertical") * Time.deltaTime * 9;
            transform.Rotate(0, horizontalmove, 0);
            transform.Translate(0, 0, verticalmove);
        }
        else if (Input.GetButton("Horizontal") || Input.GetButton("Vertical") && running)
        {
            controller.Play("Run");
            horizontalmove = Input.GetAxis("Horizontal") * Time.deltaTime * 150;
            verticalmove = Input.GetAxis("Vertical") * Time.deltaTime * 9;
            transform.Rotate(0, horizontalmove, 0);
            transform.Translate(0, 0, verticalmove);
        }
        else
        {
            controller.Play("Idle");
        }
    }
}
