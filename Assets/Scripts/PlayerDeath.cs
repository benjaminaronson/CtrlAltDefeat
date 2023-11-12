using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject respawnPoint;

    Rigidbody2D rb;
    SpriteRenderer sp;
    float fixedDeltaTime;
    // Start is called before the first frame update
    void Start()
    {
        fixedDeltaTime = Time.fixedDeltaTime;
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
    }

    public void die()
    {
        PlayerMovement.dead = true;
        //StartCoroutine(Died());
        
        // reset velocity
        rb.velocity = Vector3.zero;
        /*sp.sprite = dead1;
        StartCoroutine(Died());
        sp.sprite = dead2;
        StartCoroutine(Died());*/
        transform.position = respawnPoint.transform.position;

        // unfreeze everything
        // find all sections
        GameObject[] sections = GameObject.FindGameObjectsWithTag("section");

        foreach (GameObject section in sections) {
            section.GetComponent<PauseScreen>().isPaused = false;
        }
    }
    IEnumerator Died()
    {
        yield return new WaitForSeconds(0.05f);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            
            die();
        }
    }*/
}
