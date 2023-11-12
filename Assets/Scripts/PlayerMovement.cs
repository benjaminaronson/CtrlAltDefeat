using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.U2D;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    
    public float movementSpeed = 2.0f;

    public Sprite idleSprite;
    public Sprite jumpUp;
    public Sprite jumpDown;

    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer sr;

    private float m_horizontalMovement = 0.0f;
    private bool m_jumping = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // get input for fixed update method
        m_horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            m_jumping = true;
        }

        if(controller.isGrounded())
        {
            // enable animation + use idle sprite
            sr.sprite = idleSprite;
            animator.enabled = true;

            // running animation
            animator.SetBool("IsRunning", m_horizontalMovement != 0.0f);
        } else
        {
            // disable animation
            animator.enabled = false;

            if(rb.velocity.y > 0.0f)
            {
                sr.sprite = jumpUp;
            } else
            {
                sr.sprite = jumpDown;
            }
        }
    }

    private void FixedUpdate()
    {
        float move = (m_horizontalMovement * movementSpeed) * Time.fixedDeltaTime;
        
        controller.Move( move, false, m_jumping );
        m_jumping = false;
    }
}
