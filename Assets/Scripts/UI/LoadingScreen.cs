﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
public class LoadingScreen : MonoBehaviour {


    public Slider slider;
    public void LoadLevel (int sceneIndex) {
        StartCoroutine(LoadAsync(sceneIndex));
        
	}
	IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
	

}
