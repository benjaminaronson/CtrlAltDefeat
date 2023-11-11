using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public string nextLevelScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // check for player
        if(collision.gameObject.CompareTag("Player"))
        {
            if(nextLevelScene != "") SceneManager.LoadScene(nextLevelScene);
        }
    }
}
