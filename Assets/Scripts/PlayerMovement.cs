using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;

    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    private enum MovementState{idle, running, jumping, falling}
    private MovementState state = MovementState.idle;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      coll = GetComponent<BoxCollider2D>();
      anim = GetComponent<Animator>();
      sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(dirX * moveSpeed, rb.linearVelocity.y);
        
        if( Input.GetButtonDown("Jump") && IsGrounded() ){
            jumpSoundEffect.Play();
            rb.linearVelocity = new Vector2(dirX * moveSpeed, jumpForce);
        }
        UpdateAnimationMovement(dirX);

    }

    private void UpdateAnimationMovement(float dirX){
        if( dirX > 0f ){
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if( dirX < 0f ){
            state = MovementState.running;
            sprite.flipX = true;
        }
        else{
            state = MovementState.idle;
        }

        if( rb.linearVelocity.y > .1f ){
            state = MovementState.jumping;
        }
        else if(rb.linearVelocity.y < -.1f){
            state = MovementState.falling;
        }

        anim.SetInteger("state",(int)state);
    }

    private bool IsGrounded(){
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,.1f, jumpableGround );
    }
}