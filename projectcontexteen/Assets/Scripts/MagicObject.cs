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

	public bool[] SetValue = new bool[3];
	public GameObject[] ArtistObject;

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
				if (!SetValue[0])
				{
					InteractiveArtHUD.SetActive(true);
				}
			} else if (collision.gameObject.name == "Designer")
			{
				if (!SetValue[1])
				{
					InteractiveDesignHUD.SetActive(true);
				}
			} else if (collision.gameObject.name == "Dev")
			{
				if (!SetValue[2])
				{
					InteractiveDevHUD.SetActive(true);
				}
			} 
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			if (collision.gameObject.name == "Artist")
			{
				if (!SetValue[0])
				{
					InteractiveArtHUD.SetActive(false);
				}
			}
			else if (collision.gameObject.name == "Designer")
			{
				if (!SetValue[1])
				{
					InteractiveDesignHUD.SetActive(false);
				}
			}
			else if (collision.gameObject.name == "Dev")
			{
				if (!SetValue[2])
				{
					InteractiveDevHUD.SetActive(false);
				}
			}
		}
		Debug.Log(collision.gameObject.name);
	}

	public virtual void SetArt1()
	{

	}
	public virtual void SetArt2()
	{

	}
	public virtual void SetArt3()
	{

	}

	public virtual void SetDesign1()
	{

	}
	public virtual void SetDesign2()
	{

	}
	public virtual void SetDesign3()
	{

	}

	public virtual void SetDev1()
	{

	}
	public virtual void SetDev2()
	{

	}
	public virtual void SetDev3()
	{

	}
}
