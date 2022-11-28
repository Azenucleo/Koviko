using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour {
    [Header("Health")]
    private float health;
    [SerializeField] private float maxHealth;

    private void Start() {
        health = maxHealth;
    }

    public GameObject HealthEnemy;
   public Image life;

   public void InitilizeBar() {
        this.health = this.maxHealth;
       life.fillAmount = this.maxHealth;
   }

   public void UpdateHealthBar(float value) {
       life.fillAmount = (float)value / maxHealth;
    }

    public void TakeDamage(float damage) {
        health -= damage;
        Animator anim;
        anim = GetComponent<Animator>();
        anim.SetTrigger("hit");
        UpdateHealthBar(health);
        HealthEnemy.SetActive(true);
        
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
//    public int damage;
//    //protected int currentHealth;
//    private float health;
//    [SerializeField] private int maxHealth;
//
//
//    public void TakeDamage(int damage) {
//        health -= damage;
//        UpdateHealthBar(health);
//        healthBar.SetActive(true);
//
//        if(health <= 0) {
//            Destroy(gameObject);
//        }
//    }
//}
