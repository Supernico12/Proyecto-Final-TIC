using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarManager : MonoBehaviour {

    float currHealth;
    public Slider slider;
    CharacterStats health;
    float maxHealth;
	

	void Start () {
        health = GetComponent<CharacterStats>();
	}
	

	void Update () {
        currHealth = health.GetHealth;
        maxHealth = health.GetMaxHealth;
        slider.value = currHealth / maxHealth;

	}
}
