using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider healthSlider;
    public GameObject gameOverPanel;

    private float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.value = currentHealth;
        UpdateSlider();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        healthSlider.value = currentHealth / maxHealth;
    }
}
