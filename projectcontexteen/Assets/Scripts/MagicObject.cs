using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.UI;
using TMPro;

public class MagicObject : MonoBehaviour
{
	public GameObject InteractiveArtHUD;
	public GameObject InteractiveDesignHUD;
	public GameObject InteractiveDevHUD;

	private void Start()
	{
		InteractiveArtHUD.SetActive(false);
		InteractiveDesignHUD.SetActive(false);
		InteractiveDevHUD.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
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
