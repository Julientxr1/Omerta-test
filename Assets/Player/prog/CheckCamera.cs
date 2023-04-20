using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class CheckCamera : MonoBehaviour
{
    public GameObject playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            playerCamera.SetActive(true);
        }
    }
}
