using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject[] items;

    private bool check;
    // Start is called before the first frame update

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Out");
        check = true;
    }

    private void Update()
    {
        if (check)
        {
            foreach (var VARIABLE in items)
            {
                VARIABLE.SetActive(false); }
        }
    }
}
