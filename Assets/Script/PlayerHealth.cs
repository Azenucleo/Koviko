using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour {
    //private float health = 0f;
    //[SerializeField] private float maxHealth = 100f;
    public float currentHealth;
    public float maxHealth;
    [SerializeField] private Slider healthSlider;

    private void Start() {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
    }

    public void UpdateHealth(float mod) {
        currentHealth += mod;

        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        } else if (currentHealth <= 0f) {
            currentHealth = 0f;
            healthSlider.value = currentHealth;
            Destroy(gameObject);
        }
    }

    private void OnGUI() {
        float t = Time.deltaTime / 1f;
        healthSlider.value = Mathf.Lerp(healthSlider.value, currentHealth, t);
    }

    public void TakeDamage(float damage) {
        currentHealth -= damage;
    }
}