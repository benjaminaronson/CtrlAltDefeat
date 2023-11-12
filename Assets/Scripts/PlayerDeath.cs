using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject respawnPoint;
    public static int deaths;
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
        //Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
    }

    public void die()
    {

        deaths++;
        //PlayerMovement.dead = true;
        
        // reset velocity
        rb.velocity = Vector3.zero;
        
        transform.position = respawnPoint.transform.position;

        // unfreeze everything
        // find all sections
        GameObject[] sections = GameObject.FindGameObjectsWithTag("section");

        foreach (GameObject section in sections) {
            section.GetComponent<PauseScreen>().isPaused = false;
        }

        // delete all cannonballs
        // TODO: this sucks
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            Cannonball cn = enemy.GetComponent<Cannonball>();
            if (cn != null)
            {
                cn.Destruct();
            }
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
