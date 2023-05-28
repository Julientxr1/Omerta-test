using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Mission2_scene : MonoBehaviour
{
    public string NomDescene;

    public void ChangeScene()
    {
        SceneManager.LoadScene(NomDescene);
    }

    private void OnTriggerEnter(Collider other)
    {
        ChangeScene();
    }
}
