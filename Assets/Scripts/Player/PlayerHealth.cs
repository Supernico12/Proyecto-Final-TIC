using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    CharacterStats playerStats;
    [SerializeField]
    Image healthUI;

    [SerializeField] float recoveryTime = 3;
    float lastDamage;
    void Start()
    {
        playerStats = PlayerManager.instance.player.GetComponent<CharacterStats>();
        playerStats.OnTakeDamage += OnAttacked;

    }
    void Update()
    {
        lastDamage -= Time.deltaTime;

        if (lastDamage < 0 && playerStats.GetHealth != playerStats.GetMaxHealth)
        {
            playerStats.TakeDamage(-1);
            UpdateHealth();
        }
    }
    void OnAttacked()
    {
        lastDamage = recoveryTime;
        UpdateHealth();
    }
    void UpdateHealth()
    {

        Color c = healthUI.color;
        c.a = -((playerStats.GetHealth / playerStats.GetMaxHealth) - 1);

        healthUI.color = c;


        // .8 / 1
    }

}
