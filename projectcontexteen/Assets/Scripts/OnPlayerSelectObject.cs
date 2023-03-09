using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class OnPlayerSelectObject : NetworkBehaviour
{
	public GameObject InterfaceHUD;
	public Text[] SelectButtonsText = new Text[3];
	private string PlayerClass;

	void Awake()
	{
		PlayerClass = GetComponent<IsPlayerClass>().PlayerClass;
		InterfaceHUD = transform.GetChild(0).gameObject;
		



		SetHUDOff();
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("MagicObject"))
		{
			InterfaceHUD.SetActive(true);

			switch (PlayerClass)
			{
				case "Artist":
					SetButtonText("Doorway", "FlatPlatform", "Jar of PeanutButter"); 
					break;

				case "Designer":
					SetButtonText("Fly Around is a circle", "Grow and Shrink in Size", "Explode and Cause Knockback upwards");
					break;

				case "Dev":
					SetButtonText("Activate when Touched", "Loop every 3 seconds", "Activate when not Touched");
					break;
			}
		}
	}

	private void SetButtonText(string _Artist, string _Designer, string _Dev)
	{
		SelectButtonsText[0].text = _Artist;
		SelectButtonsText[1].text= _Designer;
		SelectButtonsText[2].text= _Dev;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("MagicObject"))
		{
			SetHUDOff();
		}
	}

	public void SetHUDOff()
	{
		if (!IsOwner) { return; }
		InterfaceHUD.SetActive(false);
	}
}
