using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void Select_Level(int n)
    {
        SceneManager.LoadScene(n);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
