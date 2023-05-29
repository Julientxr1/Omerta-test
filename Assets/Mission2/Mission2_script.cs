using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission2_script : MonoBehaviour
{
    public GameObject me;
    public GameObject ChangeScene;
    private bool MissionStart;
    public bool Doc;
    private bool up;
    public string tag1;
    public GameObject MissionOneTxt;
    public GameObject MissionCondition;
    public GameObject MissionDirection;

    // Start is called before the first frame update
    void Start()
    {
        me.SetActive(true);
        MissionDirection.SetActive(false);
        MissionCondition.SetActive(false);
        MissionOneTxt.SetActive(false);
        ChangeScene.SetActive(false);
        MissionStart = false;
        Doc = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                MissionStart = true;
                MissionCondition.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                MissionStart = false;
                MissionOneTxt.SetActive(false);
                MissionCondition.SetActive(false);
            }
        }
        
        if (MissionStart)
        {
            MissionTwo();
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tag1)
        {
            MissionOneTxt.SetActive(true);
            MissionCondition.SetActive(true);
            Debug.Log("touch");
            up = true;
        }
    }

    void MissionTwo()
    {
        ChangeScene.SetActive(true);
        MissionDirection.SetActive(true);
        MissionOneTxt.SetActive(false);
        me.SetActive(false);
    }

}
