using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour {
    [SerializeField]
    Transform reloadParent;

   
    PlayerMotor motor;
    Text ammoText;
	// Use this for initialization
	void Start () {
        
        ammoText = reloadParent.GetComponentInChildren<Text>();
        motor = PlayerManager.instance.player.GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {

        UpdateAmmo();
	}

    void UpdateAmmo()
    {

        ammoText.text = motor.GetCurrentAmmo.ToString() + " / " + motor.GetCurrentWeapon.maxAmmo.ToString()  ;
    } 
}
