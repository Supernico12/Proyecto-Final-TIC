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
    public float time;
    float waitTime = 9;

    public bool lvls;
    int finish = 2;
    public bool lol;
    public bool lol2;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       // if(lvls)
        //waitTime -= Time.deltaTime;

        
	}

    public void LoadLevel()
    {
        
        screen.SetActive(true);
        index = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadAsync(index + 1));

    }
    public void AddEnemy(int cantEnemy)
    {
        enemyCount += cantEnemy;
        started = true;
    }
    public void RemoveEnemy(int cantEnemy)
    {
        enemyCount -= cantEnemy;

        if (enemyCount <= 1 && lol == false)
        {
            Debug.Log("Hs mtdo  todos los enemigos");
            //levelFinished = true;
            lvls = true;
            lol = true;
            //levelFinished = false;

           
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
