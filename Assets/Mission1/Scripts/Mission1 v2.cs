using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission1v2 : MonoBehaviour
{
    public GameObject[] MissionItems;
    bool MissionStarted;
    public string tag1;
    public GameObject MissionOneTxt;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in MissionItems)
        {
            item.SetActive(false);
        }
        MissionStarted = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (MissionStarted)
        {
            MissionOne();
        }

    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == tag1)
        {
            MissionStarted = true;
            MissionOneTxt.SetActive(false);
        }  
    }

    void MissionOne()
    {
        foreach (var item in MissionItems)
        {
            item.SetActive(true);
        }
    }
}
