using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      anim = GetComponent<Animator>();
      sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(dirX * moveSpeed, rb.linearVelocity.y);
        
        // fixing multiple jumping
        if( Math.Abs(rb.linearVelocity.y) < .1f && Input.GetButtonDown("Jump") ){
            rb.linearVelocity = new Vector2(dirX * moveSpeed, jumpForce);
        }
        UpdateAnimationMovement(dirX);

    }

    private void UpdateAnimationMovement(float dirX){
        if( dirX > 0f ){
            anim.SetBool("running",true);
            sprite.flipX = false;
        }
        else if( dirX < 0f ){
            anim.SetBool("running",true);
            sprite.flipX = true;
        }
        else{
            anim.SetBool("running",false);
        }
    }
}
