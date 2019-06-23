﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

    void Start(){
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
    }
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("QUIT!");
    }
}
