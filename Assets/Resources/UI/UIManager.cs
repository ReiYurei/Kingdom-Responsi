using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Slider HealthSlider;
    PlayerController playerController;

    public GameObject DeathPanel;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerController.OnDamageEvent += OnDamageUI;
        playerController.OnDeath += OnDeathUI;

        HealthSlider.value = HealthSlider.maxValue;

    }
    void OnDamageUI(float attackPower, Color color)
    {
        HealthSlider.value -= attackPower;
    }

    void OnDeathUI(object sender, EventArgs e)
    {
        DeathPanel.gameObject.SetActive(true);
    }
}
