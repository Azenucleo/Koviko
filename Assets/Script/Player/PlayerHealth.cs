using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public static PlayerHealth playerStats;

    public float health;
    public float maxHealth;

    public int coins;
    public int gems;

    public Text coinsValue;
    public Text gemsValue;
    [SerializeField] private Slider healthSlider;

    void Awake() {
        playerStats = this;
        DontDestroyOnLoad(this);
    }

    private void Start() {
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
    }

    public void TakeDamage(float damage) {
        health -= damage;
        if (health > maxHealth) {
            health = maxHealth;
        } else if (health <= 0f) {
            health = 0f;
            healthSlider.value = health;
            PlayerDied();
            //Destroy(gameObject);
        }
    }

    private void PlayerDied() {
        LevelManager.instance.GameOver();
        gameObject.SetActive(false);
    }

    private void OnGUI() {
        float t = Time.deltaTime / 1f;
        healthSlider.value = Mathf.Lerp(healthSlider.value, health, t);
    }

    public void AddCurrency(CurrenctPickup currency) {
        if(currency.currentObject == CurrenctPickup.PickupObject.COIN) {
            coins += currency.pickupQuantity;
            coinsValue.text = "Gold: " + coins.ToString();
        }
        else if (currency.currentObject == CurrenctPickup.PickupObject.GEM) {
            gems += currency.pickupQuantity;
            gemsValue.text = "Gems: " + gems.ToString();
        }

    }
}