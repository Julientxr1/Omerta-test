using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class AimStateManager : MonoBehaviour
{
    public Cinemachine.AxisState xAxis, yAxis;
    [SerializeField] private Transform Camfollowpose;

     void Start()
    {
        throw new NotImplementedException();
    }

     void Update()
     {
         xAxis.Update(Time.deltaTime);
         yAxis.Update(Time.deltaTime);
     }

     void LateUpdate()
     {
         Camfollowpose.localEulerAngles = new Vector3(yAxis.Value, Camfollowpose.localEulerAngles.y,
             Camfollowpose.localEulerAngles.z);
         transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis.Value, transform.eulerAngles.z);
     }
}
