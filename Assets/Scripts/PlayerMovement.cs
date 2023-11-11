using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static bool dead = false;
    Rigidbody2D rb;
    public float jump_velocity = 17;
    bool grounded = true;
    float speed = 10.0f;
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            float x_movement = Input.GetAxis("Horizontal");

            Vector2 movement = new Vector2(x_movement, 0f);
            transform.Translate(movement * speed * Time.deltaTime);
            bool is_jumping = Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.W);
            if (is_jumping && grounded) Jump();
        }
    }

    void Jump()
    {
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
}
