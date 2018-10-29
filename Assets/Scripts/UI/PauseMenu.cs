using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {

    public static bool isPaused;
    public GameObject pauseMenuUI;
    PlayerMotor motor;
    GameObject instance;
    float sensibility;
    public GameObject OptionsMenuUI;
	// Use this for initialization
	void Start () {
        instance = PlayerManager.instance.player;
        motor = instance.GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
                Cursor.lockState = CursorLockMode.Locked;
                
            }
            else
            {
                Pause();
                Cursor.lockState = CursorLockMode.None;
                motor.SetSensibility(0f);
            }

        }
	}
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        motor.SetSensibility(sensibility);
        OptionsMenuUI.SetActive(false);
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        isPaused = false;
    }
    public void Exit()
    {
        Time.timeScale = 1f;
        Application.Quit();
        Debug.Log("QUIT");
        isPaused = false;
    }
    
    public void Sensitivity(float newSens)
    {
        Debug.Log(sensibility);
        sensibility = newSens;
    }

}
