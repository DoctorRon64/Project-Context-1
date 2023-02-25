using UnityEngine;
using Unity.Netcode;

public class IsPlayerClass : NetworkBehaviour
{
    public int PlayerClass;
    public Sprite[] PlayerClassSprites;
    public SpriteRenderer SpriteRender;

	private void Start()
	{		
		SpriteRender = GetComponent<SpriteRenderer>();
		switch (PlayerClass)
		{
			case 0: PlayerIsArtist(); break;
			case 1: PlayerIsDesigner(); break;
			case 2: PlayerIsDev(); break;
		}
	}

	private void Update()
	{
		Flip();
	}

	public void Flip()
	{
		if (GetComponent<PlayerController>().horizontalInput > 0f)
		{
			SpriteRender.flipX = false;
		}
		else if (GetComponent<PlayerController>().horizontalInput < 0f)
		{
			SpriteRender.flipX = true;
		}
	}

	private void PlayerIsArtist() { SpriteRender.sprite = PlayerClassSprites[PlayerClass]; }
    private void PlayerIsDesigner() { SpriteRender.sprite = PlayerClassSprites[PlayerClass]; }
    private void PlayerIsDev() { SpriteRender.sprite = PlayerClassSprites[PlayerClass]; }

}