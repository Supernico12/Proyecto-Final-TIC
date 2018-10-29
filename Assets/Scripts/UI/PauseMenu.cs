using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused;
    public GameObject pauseMenuUI;
    SettingsMenu settings;
    PlayerMotor motor;
    public float sensibility;
    public GameObject BossHealth;
	// Use this for initialization
	void Start () {
        motor = PlayerManager.instance.player.GetComponent<PlayerMotor>();
        sensibility = motor.sensibility;
        settings = GetComponentInChildren<SettingsMenu>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
                
            }
            else
            {
                Pause();
                Cursor.lockState = CursorLockMode.None;

            }

        }
	}
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        isPaused = false;
        motor.SetSensibility(sensibility);
        if (BossHealth != null)
        {
            BossHealth.SetActive(true);
        }

    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        
        motor.SetSensibility(0);
        if(BossHealth != null)
        {
            BossHealth.SetActive(false);
        }
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
    public void getSensibility(float sens)
    {
        sensibility = sens;
    }
    
}
