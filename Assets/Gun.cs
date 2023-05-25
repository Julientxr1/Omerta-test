using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletspawn;
    public GameObject bulletprefab;
    public float speed;
    
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var bullet = Instantiate(bulletprefab, bulletspawn.position, bulletspawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletspawn.forward * speed;
        }
    }
}
