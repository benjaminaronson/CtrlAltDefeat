using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInAndOut : MonoBehaviour
{
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
                sr.color = new Color(1, 1, 1, sr.color.a + 0.0005f);
            }
            else isFadingIn = false;
            StartCoroutine(waitFiveSeconds());
        }
        
        else
        {
            if (sr.color.a > 0) {
                sr.color = new Color(1, 1, 1, sr.color.a - 0.0005f);
            }
            else
            {
                SceneManager.LoadScene("IntroScreen");
            }

        }
    }
    IEnumerator waitFiveSeconds()
    {
        yield return new WaitForSeconds(5);
    }
}
