using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class SwitchCarPlayer : MonoBehaviour
{

    private bool useCar = false;
    public Text text;
    public GameObject Player;
    public GameObject Car;
    public GameObject Camera;
    public GameObject CameraCar;
    // Start is called before the first frame update
    void OnTriggerEnter (Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            text.enabled = true;
            Debug.Log("touch");
        }
    }
    
    void OnTriggerExit (Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            text.enabled = false;
            Debug.Log("out");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            useCar =! useCar;
            if (useCar)
            {
                text.enabled = false;
                Player.SetActive(false);
                Camera.SetActive(false);
                CameraCar.SetActive(true);
                Car.GetComponent<CarController>().enabled = true;
            }
            else
            {
                Player.SetActive(true);
                Camera.SetActive(true);
                CameraCar.SetActive(false);
                Player.transform.position = Car.transform.position - (Vector3.right * 3);
                Car.GetComponent<CarController>().enabled = false;
            }
        }
    }
}
