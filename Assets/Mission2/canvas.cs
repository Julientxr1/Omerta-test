using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvas : MonoBehaviour
{
    public GameObject canvas1;

    public bool set;

    public string tag1;
    // Start is called before the first frame update
    void Start()
    {
        set = false;
        canvas1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (set)
        {
            canvas1.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tag1)
        {
            set = true;
        }
    }
}
