using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public GameObject[] MissionItems;
    private bool MissionStart;
    public string tag1;
    public GameObject MissionOneTxt;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in MissionItems)
        {
            obj.SetActive(false);
        }
        
        MissionStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (MissionStart)
        {
            MissionOne();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tag1)
        {
            MissionStart = true;
            MissionOneTxt.SetActive(false);
        }
    }

    void MissionOne()
    {
        foreach (GameObject obj in MissionItems)
        {
            obj.SetActive(true);
        }
    }
}
