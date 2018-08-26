using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    #region Singelton

    public static PlayerManager   instance;
    private void Awake()
    {
        if( instance != null)
        {
            Debug.LogWarning("Trying To Instance 2 Player Managers");
            return;
        }
        instance = this;
        

    }
    #endregion

    public GameObject player;
    public Transform playertransform;
   

}
