using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    [Header("Component")]
    Rigidbody2D rb;
    Animator anim;

    [Header("Stat")]
    [SerializeField]
    float moveSpeed;
    //public int currentHealth;
    //public int maxHealth;



    public static BasicMovement instance;

    private void Awake() {
        instance = this;
    }

    void Start() {
        //currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        Move();
    }



    void Move() {

        if(Input.GetAxis("Horizontal") > 0.1 || Input.GetAxis("Horizontal") < -0.1 || Input.GetAxis("Vertical") > 0.1 || Input.GetAxis("Vertical") < -0.1 ) {
            anim.SetFloat("lastInputX", Input.GetAxis("Horizontal"));
            anim.SetFloat("lastInputY", Input.GetAxis("Vertical"));
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(x,y)* moveSpeed * Time.fixedDeltaTime;
        rb.velocity.Normalize();

        if(x !=0 || y != 0) {
            anim.SetFloat("inputX", x);
            anim.SetFloat("inputY", y);
        }
    }

    //public void TakeDamage(int damage) {
    //    currentHealth -= damage;
    //}
    
}
