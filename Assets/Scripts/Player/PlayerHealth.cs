using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    CharacterStats playerStats;
    [SerializeField]
    Image healthUI;

    [SerializeField] float recoveryTime;
    float lastDamage;
    void Start()
    {
        playerStats = PlayerManager.instance.player.GetComponent<CharacterStats>();
        playerStats.OnTakeDamage += OnChangeHealth;

    }
    void Update()
    {
        lastDamage -= Time.deltaTime;

        if (lastDamage < 0 && playerStats.GetHealth != playerStats.GetMaxHealth)
        {
            playerStats.TakeDamage(-1);
            OnChangeHealth();
        }
    }
    void OnChangeHealth()
    {

        Color c = healthUI.color;
        c.a = -((playerStats.GetHealth / playerStats.GetMaxHealth) - 1);

        healthUI.color = c;
        lastDamage = recoveryTime;

        // .8 / 1
    }

}
