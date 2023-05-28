using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission2_script : MonoBehaviour
{
    public GameObject Mission1;
    public GameObject ChangeScene;
    private bool MissionStart;
    private bool Doc;
    public string tag1;
    
    // Start is called before the first frame update
    void Start()
    {
        Mission1.SetActive(false);
        ChangeScene.SetActive(false);
        MissionStart = false;
        Doc = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (MissionStart)
        {
            ChangeScene.SetActive(true);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tag1)
        {
            MissionStart = true;
        }
    }

    void MissionTwo()
    {
        Mission1.SetActive(true);
    }
}
