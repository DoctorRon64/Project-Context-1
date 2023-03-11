using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine.UI;

public class MagicObjectBehaviour : NetworkBehaviour
{
    public GameObject InteractiveHUD;

	private void Start()
	{
		//if (!IsOwner) return;
		InteractiveHUD.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Artist"))
		{
			InteractiveHUD.SetActive(true);
			Debug.Log("Artist");
		}

		if (collision.CompareTag("Designer"))
		{
			InteractiveHUD.SetActive(true);
			Debug.Log("Design");
		}

		if (collision.CompareTag("Dev"))
		{
			InteractiveHUD.SetActive(true);
			Debug.Log("Dev");
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Artist"))
		{
			InteractiveHUD.SetActive(false);
		}

		if (collision.CompareTag("Designer"))
		{
			InteractiveHUD.SetActive(false);
		}

		if (collision.CompareTag("Dev"))
		{
			InteractiveHUD.SetActive(false);
		}
	}
}
