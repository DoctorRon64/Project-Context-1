using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWhenNOTouch : MonoBehaviour
{
	SpriteRenderer spriteRenderer;
	BoxCollider2D boxcol2d;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		boxcol2d = GetComponent<BoxCollider2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			spriteRenderer.enabled = false;
			boxcol2d.enabled = false;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			spriteRenderer.enabled = true;
			boxcol2d.enabled = true;
		}
	}
}
