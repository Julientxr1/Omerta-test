using System;
using UnityEngine;

public class MouvementStateManager : MonoBehaviour
{
    public float movespeed = 3;
    [HideInInspector] public Vector3 dir;
    private float hzInput, vInput;
    private CharacterController Controller;
    [SerializeField] float groundOffset;
    [SerializeField] private LayerMask groundmask;
    private Vector3 spherepos;
    [SerializeField] private float gravity = -9.81f;
    private Vector3 velocity;
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

     void Update()
    {
        Getdirection();
        Gravity();
        
    }

     void Getdirection()
     {
         hzInput = Input.GetAxis("Horizontal");
         vInput = Input.GetAxis("Vertical");
         dir = transform.forward * vInput + transform.right * hzInput;

         Controller.Move(dir * (movespeed * Time.deltaTime));
     }

     bool IsGrounded()
     {
         spherepos = new Vector3(transform.position.x, transform.position.y - groundOffset, transform.position.z);
         if (Physics.CheckSphere(spherepos,Controller.radius-0.05f,groundmask))
         {
             return true;
         }
         else
         {
             return false;
         }
     }

     void Gravity()
     {
         if (!IsGrounded())
         {
             velocity.y += gravity * Time.deltaTime;
             
         }
         else if (velocity.y<0)
         {
             velocity.y = -2;
         }

         Controller.Move(velocity * Time.deltaTime);
     }

     private void OnDrawGizmos()
     {
         Gizmos.color= Color.red;
         Gizmos.DrawWireSphere(spherepos,Controller.radius-0.05f);
     }
}