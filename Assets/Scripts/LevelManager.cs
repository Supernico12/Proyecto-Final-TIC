using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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
    public float time;
    float waitTime = 9;

    public bool lvls;
    int finish = 2;
    public bool lol;
    public bool lol2;


    public TMP_Text text;
	void Start () {
		
	}

    [SerializeField]
    KeyCode[] changeLvlKeyCodes;
	// Update is called once per frame
	void Update () {
        index = SceneManager.GetActiveScene().buildIndex;
        
        
        if(index != 3&&index != 0 ) { 
        text.text = "Enemies Left: " + (enemyCount - 1);
        }

        for(int i = 0; i < changeLvlKeyCodes.Length; i++)
        {
            if (Input.GetKeyDown(changeLvlKeyCodes[i]))
            {
                if (SceneManager.sceneCountInBuildSettings > i)
                {

                LoadLevel(i);
                }
            }
        }
    }

    public void LoadLevel()
    {
        
        screen.SetActive(true);
        index = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadAsync(index + 1));
        

    }

    public void LoadLevel(int index)
    {
        StartCoroutine(LoadAsync(index));
    }
    public void AddEnemy(int cantEnemy)
    {
        
        enemyCount += cantEnemy;
        
    }
    public void RemoveEnemy(int cantEnemy)
    {
        enemyCount -= cantEnemy;

        if (enemyCount <= 1 && lol == false)
        {         
            lvls = true;
            lol = true; 
           
        }
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
