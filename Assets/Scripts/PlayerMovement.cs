using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    public Sprite jump_up;
    public Sprite jump_down;
    public Sprite idle;
    SpriteRenderer sr;
    public static bool dead = false;
    Rigidbody2D rb;
    public float jump_velocity = 17;
    bool grounded = true;
    float speed = 10.0f;
    public static int score = 0;

    private float m_defaultX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        m_defaultX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            float x_movement = Input.GetAxis("Horizontal");
            if (x_movement > 0)
            {
                if (grounded)
                anim.SetBool("IsRunning", true);
                transform.localScale = new Vector3(m_defaultX, transform.localScale.y, transform.localScale.z);
            }
            else if (x_movement < 0)
            {
                if (grounded)
                {
                    
                    anim.SetBool("IsRunning", true);
                }
                
                transform.localScale = new Vector3(-m_defaultX, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                anim.SetBool("IsRunning", false);
            }

            Vector2 movement = new Vector2(x_movement, 0f);
            transform.Translate(movement * speed * Time.deltaTime);
            bool is_jumping = Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.W);
            if (is_jumping && grounded) Jump();
            
            if (rb.velocity.y > 0f && !grounded)
            {
                anim.enabled = false;
                sr.sprite = jump_up;
                
            }
            if (grounded)
            {
                anim.enabled = true;
                sr.sprite = idle; 
            }
            else if (rb.velocity.y < 0f)
            {
                anim.enabled = false;
                sr.sprite = jump_down;
                
            }
            /*else
            {
                if (rb.velocity.x == 0f)
                {
                    
                }
            }*/
        }
    }

    void Jump()
    {
        GetComponent<SpriteRenderer>().sprite = jump_up;
        rb.velocity = new Vector2(rb.velocity.x, jump_velocity);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            grounded = true;
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") || collision.collider.GetType() == typeof(CircleCollider2D) 
            || collision.gameObject.CompareTag("Enemy"))
        {
            grounded = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }
    }
}
