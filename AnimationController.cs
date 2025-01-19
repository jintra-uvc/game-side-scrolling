using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Animator animator;

    public bool IsGround;

    // public Health playerHealth;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGround && Input.GetButtonDown("Jump"))
        {
            animator.SetBool("Jump", true);
            IsGround = false;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = false;
        }

        // if(playerHealth.currentHP <= 0)
        // {
        // //animator.SetTrigger("Die");
        // }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGround = true;
            animator.SetBool("Jump", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    //animator.SetTrigger("Attacked");
        //}
    }
}