using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressStart : MonoBehaviour
{
    SpriteRenderer sr;
    [SerializeField] Sprite onHover;
    [SerializeField] Sprite offHover;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        sr.sprite = onHover;
    }
    private void OnMouseExit()
    {
        sr.sprite = offHover;
    }
    private void OnMouseDown()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }
}
