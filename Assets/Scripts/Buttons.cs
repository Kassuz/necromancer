﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Buttons : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}