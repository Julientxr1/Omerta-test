using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Vector2 turn;
    public float sensivity = .5f;

    private void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensivity;
        turn.y += Input.GetAxis("Mouse Y") * sensivity;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}