using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.UI;
using TMPro;

public class MagicObjectCollider : MonoBehaviour
{
	public GameObject InteractiveArtHUD;
	public GameObject InteractiveDesignHUD;
	public GameObject InteractiveDevHUD;
	
	public bool PlayerInRange = false;

	private void Start()
	{
		InteractiveArtHUD.SetActive(false);
		InteractiveDesignHUD.SetActive(false);
		InteractiveDevHUD.SetActive(false);
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			PlayerInRange = true;
			if (collision.gameObject.name == "Artist")
			{
				InteractiveArtHUD.SetActive(true);
			} else if (collision.gameObject.name == "Designer")
			{
				InteractiveDesignHUD.SetActive(true);
			} else if (collision.gameObject.name == "Dev")
			{
				InteractiveDevHUD.SetActive(true);
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		PlayerInRange = false;
		if (collision.CompareTag("Player"))
		{
			if (collision.gameObject.name == "Artist")
			{
				InteractiveArtHUD.SetActive(false);
			}
			else if (collision.gameObject.name == "Designer")
			{
				InteractiveDesignHUD.SetActive(false);
			}
			else if (collision.gameObject.name == "Dev")
			{
				InteractiveDevHUD.SetActive(false);
			}
		}
	}
}
