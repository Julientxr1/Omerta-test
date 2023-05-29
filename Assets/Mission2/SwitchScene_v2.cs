using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene_v2 : MonoBehaviour
{
    // Start is called before the first frame update
    public string NomDeScene;

    void SwitchScene1(){
        SceneManager.LoadScene(NomDeScene);
    }

    private void OnTriggerEnter(Collider other) {
        SwitchScene1();
    }
}
