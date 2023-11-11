using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isPaused = !isPaused;
            
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
