using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;


public class Cameramouvement : MonoBehaviour
{
    public float sensi = 100;

    private void Update()
    {
        if (Input.GetAxis("Mouse X")<0)
        {
            transform.Rotate(0, -sensi * Time.deltaTime,0);

        }
        if (Input.GetAxis("Mouse X")>0)
        {
            transform.Rotate(0, sensi * Time.deltaTime,0);

        }
    }
}
