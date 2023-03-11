using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine.UI;
using TMPro;

public class MagicObjectBehaviour : NetworkBehaviour
{
    public GameObject InteractiveHUD;
	public TMP_Text Option1Text;
	public TMP_Text Option2Text;
	public TMP_Text Option3Text;

	private void Start()
	{
		if (!IsOwner) return;
		InteractiveHUD.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Artist"))
		{
			InteractiveHUD.SetActive(true);
			SetText("1", "2", "3");
			Debug.Log("Artist");
		}

		if (collision.CompareTag("Designer"))
		{
			InteractiveHUD.SetActive(true);
			SetText("1", "2", "3");
			Debug.Log("Design");
		}

		if (collision.CompareTag("Dev"))
		{
			InteractiveHUD.SetActive(true);
			SetText("1", "2", "3");
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

	private void SetText(string option1, string option2, string option3)
	{
		Option1Text.text = option1;
		Option2Text.text = option2;
		Option3Text.text = option3;
	}
}
