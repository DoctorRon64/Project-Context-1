using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PointOfCreationScript : MonoBehaviour
{
	public int ArtValues;
	public int DesignValues;
	public int DevValues;

	public MagicObjectCollider magicobjecto;
	public Button[] ClickableArtButtons;
	public Button[] ClickableDesButtons;
	public Button[] ClickableDevButtons;

	public bool[] SetHudOff = new bool[3];
	public GameObject[] ArtistObject;
	public GameObject InstantObj;
	private BoxCollider2D boxcol;
	public GameObject SpriteStuff;

	private bool PlayerInRange;
	public bool MagicUsed = false;

	private void Awake()
	{
		magicobjecto = GetComponentInChildren<MagicObjectCollider>();
		boxcol = GetComponent<BoxCollider2D>();
		for (int i = 0; i < SetHudOff.Length; i++)
        {
			SetHudOff[i] = false;
        }
	}

	private void Update()
	{
		PlayerInRange = magicobjecto.PlayerInRange;
	}

	//check stuff
	public void SetArt(int _parameter)
	{
		if (PlayerInRange && !MagicUsed)
		{
			ArtValues = _parameter;
			SetHudOff[0] = true;
			magicobjecto.InteractiveArtHUD.SetActive(false);
			//ANIMATIE SHIT HIER (ergens)
			CheckifAllTrue();
		}
	}

	public void SetDesign(int _parameter)
	{
		if (PlayerInRange && !MagicUsed)
		{
			DesignValues = _parameter;
			SetHudOff[1] = true;
			magicobjecto.InteractiveDesignHUD.SetActive(false);
			//ANIMATIE SHIT HIER (ergens)
			CheckifAllTrue();
		}
	}

	public void SetDev(int _parameter)
	{
		if (PlayerInRange && !MagicUsed)
		{
			DevValues = _parameter;
			SetHudOff[2] = true;
			magicobjecto.InteractiveDevHUD.SetActive(false);
			//ANIMATIE SHIT HIER (ergens)
			CheckifAllTrue();
		}
	}

	private void CheckifAllTrue()
	{
		if (!MagicUsed)
		{
            if (ArtValues != 0 && DesignValues != 0 && DevValues != 0)
            {
                Artify();
                Designefy();
                Devify();
				MagicUsed = true;

				magicobjecto = GetComponentInChildren<MagicObjectCollider>();
				magicobjecto.SetOffCanvas();
            }
        }
	}

	//art stuff
	private void Artify()
	{
		InstantObj = Instantiate(ArtistObject[ArtValues - 1], gameObject.transform.position, Quaternion.identity);
		InstantObj.transform.parent = gameObject.transform;

		boxcol.enabled = false;
		SpriteStuff.SetActive(false);
	}

	//design stuff
	private void Designefy()
	{
		magicobjecto.transform.position = InstantObj.transform.position;
		magicobjecto.transform.parent = InstantObj.transform;
		InstantObj.AddComponent<FlyAroundInCircles>();
		InstantObj.AddComponent<GrowAndShrink>();
	}

	//Dev Stuff
	private void Devify()
	{
		InstantObj.AddComponent<ActivateOnTouch>();
	}
}
