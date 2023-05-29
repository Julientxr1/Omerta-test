using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission2_end : MonoBehaviour
{
    public GameObject me;
    public bool key;
    // Start is called before the first frame update
    void Start()
    {
        me.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (key)
        {
            me.SetActive(true);
        }
    }
}
