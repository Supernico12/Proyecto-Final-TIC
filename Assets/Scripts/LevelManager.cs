using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    int enemyCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (enemyCount <= 0)
        {

        }

	}
    public void AddEnemy(int cantEnemy)
    {
        enemyCount += cantEnemy;
    }

    public void RemoveEnemy(int cantEnemy)
    {
        enemyCount -= cantEnemy;
    }

}
