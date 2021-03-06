﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{

    public Dropdown resolutionsDropdwon;
    Resolution[] resolutions;
    PlayerMotor motor;
    GameObject instance;
    public PauseMenu pause;
    float Sensibility;
    public float globalSens;
    Slider sens;

    public float volumeMartin;


    bool res = false;
    int currentResolutionIndex = 0;
    void Start()
    {

        instance = PlayerManager.instance.player;
        pause = GetComponentInParent<PauseMenu>();
        motor = instance.GetComponent<PlayerMotor>();
        resolutions = Screen.resolutions;
        resolutionsDropdwon.ClearOptions();
        globalSens = motor.sensibility;
        sens.value = 3f;
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionsDropdwon.AddOptions(options);
        resolutionsDropdwon.value = currentResolutionIndex;
        resolutionsDropdwon.RefreshShownValue();
        

    }
    

    
    public void setResolution(int screenResolutionIndex)
    {
        Resolution resolution = resolutions[screenResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetVolume(float volume)
    {
        volumeMartin = volume;
        //AudioKinetic.SetRTPC("volumen", volume);
        //LoHaceMartin
    }



    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }
    public void Fullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

    }

    public void SetSensibility(float newSensibility)
    {
        Sensibility = newSensibility;
        if (motor != null)
        {
            pause.getSensibility(Sensibility);
         
        }


    }

}