using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrenctPickup : MonoBehaviour {
    public enum PickupObject{COIN,GEM};
    public PickupObject currentObject;
    public int pickupQuantity;

    void OnTriggerEnter2D(Collider2D other) {
        print(other);
        if(other.name == "Player") {
            PlayerHealth.playerStats.AddCurrency(this);
            //if(currentObject == PickupObject.COIN) {
            //    PlayerHealth.playerStats.coins += pickupQuantity;
            //}
            //else if (currentObject == PickupObject.GEM) {
            //    PlayerHealth.playerStats.gems += pickupQuantity;
            //}
            Destroy(gameObject);
        }
    }
}
