using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    float fixedDeltaTime;
    // Start is called before the first frame update
    void Start()
    {
        fixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
    }

    void die()
    {
        PlayerMovement.dead = true;
        StartCoroutine(Died());
        
        transform.position = new Vector2(-7.87f, 0f);
    }
    IEnumerator Died()
    {
        Time.timeScale = 0.25f;
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1f;
        PlayerMovement.dead = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            
            die();
        }
    }
}
