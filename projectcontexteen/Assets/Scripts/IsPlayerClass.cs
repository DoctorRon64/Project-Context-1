using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Unity.Netcode;

public class IsPlayerClass : NetworkBehaviour
{
    public Sprite[] PlayerClassSprites;
    public SpriteRenderer SpriteRender;
	public BoxCollider2D BoxCollider;
	private float StartSizeX;

	public NetworkVariable<FixedString64Bytes> _PlayerClass = new NetworkVariable<FixedString64Bytes>("" , NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
	public string PlayerClass;

	private void Start()
	{
		if (IsOwner)
		{
			int temp = Random.Range(0, 3);

			switch (temp)
			{
				case 0:
					_PlayerClass.Value = "Designer";
					break;
				case 1:
					_PlayerClass.Value = "Artist";
					break;
				case 2:
					_PlayerClass.Value = "Dev";
					break;
			}
		}

		BoxCollider = GetComponent<BoxCollider2D>();
		StartSizeX = transform.localScale.x;
	}

	private void FakeStart()
	{
		SpriteRender = GetComponent<SpriteRenderer>();
		PlayerClass = _PlayerClass.Value + "";

		switch (PlayerClass)
		{
			case "Artist": PlayerIsArtist(); break;
			case "Designer": PlayerIsDesigner(); break;
			case "Dev": PlayerIsDev(); break;
		}
	}

	private void Update()
	{
		FakeStart();
		if (!IsOwner) { return; }
		Flip();
	}

	public void Flip()
	{
		if (GetComponent<PlayerController>().horizontalInput != 0f)
		{
			transform.localScale = new Vector3(StartSizeX * GetComponent<PlayerController>().horizontalInput, transform.localScale.y, 1f);
		}
	}

	private void PlayerIsArtist() 
	{ 
		SpriteRender.sprite = PlayerClassSprites[0];
        BoxCollider.size = new Vector2(4, 13f);
    }
    private void PlayerIsDesigner() 
	{
		SpriteRender.sprite = PlayerClassSprites[1];
		BoxCollider.size = new Vector2(6, 12.6f);
	}
    private void PlayerIsDev()
	{
		SpriteRender.sprite = PlayerClassSprites[2];
        BoxCollider.size = new Vector2(8, 12.7f);
    }

}