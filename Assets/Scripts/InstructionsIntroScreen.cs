using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InstructionsIntroScreen : MonoBehaviour
{
    public GameObject[] instructions;
    public GameObject hint;
    private bool instructionsVisible = true;
    private bool hasDiedFiveTimes = false;
    // Start is called before the first frame update
    void Start()
    {
        hint.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (instructionsVisible)
        {
            if (PlayerDeath.deaths > 0)
            {
                instructionsVisible = false;
                disappear();
            }
        }
        if (!hasDiedFiveTimes)
        {
            if (PlayerDeath.deaths >= 5)
            {
                hasDiedFiveTimes = true;
                giveHint();
            }
        }
    }

    void disappear()
    {
        foreach (GameObject instruction in instructions)
        {
            instruction.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    public void giveHint()
    {
        hint.GetComponent <SpriteRenderer>().enabled = true;
    }
    public void hintGoAway()
    {
        hint.GetComponent<SpriteRenderer>().enabled= false;
    }

}
