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

	private PointOfCreationScript POC;
	public bool PlayerInRange = false;

	private void Start()
	{
		POC = GetComponentInParent<PointOfCreationScript>();

        InteractiveArtHUD.SetActive(false);
		InteractiveDesignHUD.SetActive(false);
		InteractiveDevHUD.SetActive(false);
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			PlayerInRange = true;

			if (POC.MagicUsed == false)
			{
                if (collision.gameObject.name == "Artist" && !POC.SetHudOff[0])
                {
                    InteractiveArtHUD.SetActive(true);
                }
                else if (collision.gameObject.name == "Designer" && !POC.SetHudOff[1])
                {
                    InteractiveDesignHUD.SetActive(true);
                }
                else if (collision.gameObject.name == "Dev" && !POC.SetHudOff[2])
                {
                    InteractiveDevHUD.SetActive(true);
                }
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

	public void SetOffCanvas()
	{
        InteractiveArtHUD.SetActive(false);
        InteractiveDesignHUD.SetActive(false);
        InteractiveDevHUD.SetActive(false);
    }
}
