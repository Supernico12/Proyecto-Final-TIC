using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    #region Singleton
    public static LevelManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Trying To Instance 2 Player Managers");
            return;
        }
        instance = this;


    }
    #endregion


    public int index;
    [SerializeField]bool started = false;
    public int enemyCount;
    public Slider slider;
    public bool levelFinished = false;
    public GameObject screen;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
		if (started)
        {
            if(enemyCount <= 1)
            {
                levelFinished = true;
                index = SceneManager.GetActiveScene().buildIndex;
                LoadLevel(index + 1);
                screen.SetActive(true);
            }
        }
	}

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));

    }
    public void AddEnemy(int cantEnemy)
    {
        enemyCount += cantEnemy;
        started = true;
    }
    public void RemoveEnemy(int cantEnemy)
    {
        enemyCount -= cantEnemy;
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
