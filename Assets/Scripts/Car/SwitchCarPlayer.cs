using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class SwitchCarPlayer : MonoBehaviour
{

    public bool useCar = false;
    private bool Car2 = false;
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
            Car2 = true;
        }
    }
    
    void OnTriggerExit (Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            text.enabled = false;
            Debug.Log("out");
            Car2 = false;
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
                if (Car2)
                {
                    text.enabled = false;
                    Player.SetActive(false);
                    Camera.SetActive(false);
                    CameraCar.SetActive(true);
                    Car.GetComponent<CarController>().enabled = true;
                }
            }
            else
            {
                if (Car2)
                {
                    Car2 = false;
                    Player.SetActive(true);
                    Camera.SetActive(true);
                    CameraCar.SetActive(false);
                    Player.transform.position = Car.transform.position - (Vector3.right * 5);
                    Debug.Log(Car.transform.position);
                    Car.GetComponent<CarController>().enabled = false;
                }
            }
        }
    }
}