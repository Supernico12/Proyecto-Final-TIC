using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour {

    public Dropdown resolutionsDropdwon;
    Resolution[] resolutions;
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionsDropdwon.ClearOptions();

        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
        }
        resolutionsDropdwon.AddOptions(options);
    }
	public void SetVolume(float volume)
    {
        Debug.Log(volume);
        //LoHaceMartin
    }

    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }
    public void Fullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log(isFullscreen);
    }
}
