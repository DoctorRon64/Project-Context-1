using UnityEngine;
using Unity.Netcode;

public class IsPlayerClass : NetworkBehaviour
{
    public int PlayerClass;
    public Sprite[] PlayerClassSprites;
    public SpriteRenderer SpriteRender;
	public BoxCollider2D BoxCollider;

	private void Awake()
	{
		BoxCollider = GetComponent<BoxCollider2D>();
		PlayerClass = Random.Range(0, 3);
	}

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
        SpriteRender.sprite = PlayerClassSprites[PlayerClass];

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

	private void PlayerIsArtist() 
	{ 
		SpriteRender.sprite = PlayerClassSprites[PlayerClass];
		BoxCollider.offset = new Vector2(0.5f, 0);
        BoxCollider.size = new Vector2(4, 13f);
    }
    private void PlayerIsDesigner() 
	{
		SpriteRender.sprite = PlayerClassSprites[PlayerClass];
		BoxCollider.size = new Vector2(6, 12.6f);
	}
    private void PlayerIsDev()
	{
		SpriteRender.sprite = PlayerClassSprites[PlayerClass];
        BoxCollider.offset = new Vector2(-0.2f, 0);
        BoxCollider.size = new Vector2(8, 12.7f);
    }

}