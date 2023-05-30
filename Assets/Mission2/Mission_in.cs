using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_in : MonoBehaviour
{
    public Mission2_script doc;
    public string tag;
    public GameObject Select;
    public GameObject changescene;
    public GameObject finish;


    void Start()
    {
        finish.SetActive(false);
        changescene.SetActive(false);
        Select.SetActive(true);
        doc.Doc = false;
    }
    
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tag)
        {
            doc.Doc = true;
            finish.SetActive(true);
            Select.SetActive(false);
            changescene.SetActive(true);
        }
    }
    
}
