using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour {
    [SerializeField]
    Transform reloadParent;
    
   
    PlayerInventory inventory;
    TextMeshProUGUI textMaxAmmo;
    PlayerFighting motor;
    TextMeshProUGUI ammoText;
	// Use this for initialization
	void Start () {
        
       
        motor = PlayerManager.instance.player.GetComponent<PlayerFighting>();
        TextMeshProUGUI[] texts  = reloadParent.GetComponentsInChildren<TextMeshProUGUI>();
        ammoText = texts[0];
        textMaxAmmo = texts[1]; 
        inventory = PlayerInventory.instance;
	}
	
	// Update is called once per frame
	void Update () {

        UpdateAmmo();
	}

    void UpdateAmmo()
    {
        int weaponIndex = (int)motor.GetCurrentWeapon.type;
        ammoText.text = motor.GetCurrentAmmo.ToString() + " / " + motor.GetCurrentWeapon.maxAmmo.ToString();
        textMaxAmmo.text = inventory.GetAmmo(weaponIndex).ToString();
    } 
}
