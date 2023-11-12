using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInAndOut : MonoBehaviour
{
    public float fadeInSpeed;
    public float fadeOutSpeed;
    public float secondsFull = 5;

    SpriteRenderer sr;
    private bool isFadingIn;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(1, 1, 1, 0);
        isFadingIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadingIn)
        {
            if (sr.color.a < 1)
            {
                sr.color = new Color(1, 1, 1, sr.color.a + fadeInSpeed * Time.deltaTime);
            }
            else
            {
                StartCoroutine(waitSeconds(secondsFull));
                //isFadingIn = false;
            }
        }
        
        else
        {
            if (sr.color.a > 0) {
                sr.color = new Color(1, 1, 1, sr.color.a - fadeOutSpeed * Time.deltaTime);
            }
            else
            {
                SceneManager.LoadScene("IntroScreen");
            }

        }
    }
    IEnumerator waitSeconds(float time)
    {
        yield return new WaitForSeconds(time);

        isFadingIn = false;
    }
}
