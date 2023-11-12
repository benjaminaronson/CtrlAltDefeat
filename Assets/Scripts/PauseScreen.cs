using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public KeyCode pauseButton;
    public KeyCode pauseButton2;
    public GameObject instructionsController;
    public bool isPaused;
    GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseButton) || Input.GetKeyDown(pauseButton2))
        {
            
            if(instructionsController != null) 
                instructionsController.GetComponent<PressOneToStopAndStartTime>().instructionsGoAway();
            
            
            isPaused = !isPaused;

            // if setting paused to true, unfreeze any other sections
            if (isPaused)
            {
                GameObject[] otherSections = GameObject.FindGameObjectsWithTag("section");

                foreach (GameObject section in otherSections)
                {
                    PauseScreen ps = section.GetComponent<PauseScreen>();
                    if (
                        section == gameObject ||
                        this.sharesKeys(ps)
                    ) continue;

                    ps.isPaused = false;
                }
            }

            //freezeEnemies();
            
        }
    }
    /*public void freezeEnemies()
    {
        for (int i = 0; i<enemies.Length; i++) {
            Vector3 screenPoint = Camera.main.WorldToViewportPoint(enemies[i].transform.position);
            if (screenPoint.x > -9f)
            {
                enemies[i].SetActive(false);
            }
        }
    }*/

    public bool sharesKeys(PauseScreen other)
    {
        return this.pauseButton == other.pauseButton || this.pauseButton == other.pauseButton || this.pauseButton2 == other.pauseButton || this.pauseButton2 == other.pauseButton2;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isPaused)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<Freezable>().freeze();
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<Freezable>().unfreeze();
                
            }
        }
    }
}
