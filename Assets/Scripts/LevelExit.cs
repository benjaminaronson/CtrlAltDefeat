using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public string nextLevelScene;
    AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
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
            audioPlayer.Play();
            if(nextLevelScene != "") SceneManager.LoadScene(nextLevelScene);
        }
    }
}
