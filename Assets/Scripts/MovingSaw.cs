using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSaw : SimpleMovingPlatform
{
		public float rotationSpeed = 360 * 3;
	public Sprite spikey;
	public Sprite safe;

	public GameObject sawSprite;

	SpriteRenderer spriteRenderer;

		// Start is called before the first frame update
    public override void Start()
    {
			base.Start();

        spriteRenderer = sawSprite.GetComponent<SpriteRenderer>();
    }
		
    // Update is called once per frame
    public override void Update()
    {
			base.Update();

		if (!isFrozen())
		{
			platform.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            spriteRenderer.sprite = spikey;
		} else
		{
            spriteRenderer.sprite = safe;
		}
    }
		
		private void OnCollisionStay2D(Collision2D collision){
			if(collision.gameObject.tag == "Player" && !isFrozen()){
				// TODO: kill player and stuff
				collision.gameObject.GetComponent<PlayerDeath>().die();
			}
		}
}
