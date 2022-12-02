using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    [SerializeField] Transform hand;

    [Header("Component")]
    Rigidbody2D rb;
    Animator anim;

    [Header("Stat")]
    [SerializeField] float moveSpeed;


    public static BasicMovement instance;

    private void Awake() {
        instance = this;
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        RotateHand();
    }

    private void FixedUpdate() {
        Move();
    }

    void RotateHand() {
        float angle = Utility.AngleTowardsMouse(hand.position);
        hand.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }



    void Move() {

        if(Input.GetAxis("Horizontal") > 0.1) {
            anim.SetFloat("lastInputX", 1);
            anim.SetFloat("lastInputY", 0);
        }
        
        else if (Input.GetAxis("Horizontal") < -0.1 ) {
            anim.SetFloat("lastInputX", -1);
            anim.SetFloat("lastInputY", 0);
        }

        if(Input.GetAxis("Vertical") > 0.1) {
            anim.SetFloat("lastInputX", 0);
            anim.SetFloat("lastInputY", 1);
        }

        else if (Input.GetAxis("Vertical") < -0.1) {
            anim.SetFloat("lastInputX", 0);
            anim.SetFloat("lastInputY", -1);
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
    
}
