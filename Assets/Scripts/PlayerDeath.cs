using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject respawnPoint;

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

    public void die()
    {
        PlayerMovement.dead = true;
        StartCoroutine(Died());
        
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
        Time.timeScale = 0.25f;
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1f;
        PlayerMovement.dead = false;
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            
            die();
        }
    }*/
}
