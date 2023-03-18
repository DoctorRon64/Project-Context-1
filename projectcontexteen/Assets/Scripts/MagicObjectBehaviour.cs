using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MagicObjectBehaviour : MonoBehaviour
{
	public int ArtValues;
	public int DesignValues;
	public int DevValues;

	public MagicObject magicobjecto;
	public Button[] ClickableArtButtons;
	public Button[] ClickableDesButtons;
	public Button[] ClickableDevButtons;

	public GameObject[] ArtistObject;
	public GameObject InstantObj;
	private BoxCollider2D boxcol;

	private void Awake()
	{
		magicobjecto = GetComponent<MagicObject>();
		boxcol = GetComponent<BoxCollider2D>();
		magicobjecto = GetComponent<MagicObject>();
	}

	//check stuff
	public void SetArt(int _parameter)
	{
		ArtValues = _parameter;

		for (int i = 0; i < ClickableArtButtons.Length; i++)
		{
			ClickableArtButtons[i].interactable = false;
		}

		CheckifAllTrue();
	}

	public void SetDesign(int _parameter)
	{
		DesignValues = _parameter;

		for (int i = 0; i < ClickableDesButtons.Length; i++)
		{
			ClickableDesButtons[i].interactable = false;
		}

		CheckifAllTrue();
	}

	public void SetDev(int _parameter)
	{
		DevValues = _parameter;

		for (int i = 0; i < ClickableDevButtons.Length; i++)
		{
			ClickableDevButtons[i].interactable = false;
		}

		CheckifAllTrue();
	}

	private void CheckifAllTrue()
	{
		if (ArtValues != 0 && DesignValues != 0 && DevValues != 0)
		{
			Artify();
			Designefy();
			Devify();
		}
	}

	//art stuff
	private void Artify()
	{
		InstantObj = Instantiate(ArtistObject[ArtValues - 1], gameObject.transform.position, Quaternion.identity);
		InstantObj.transform.parent = gameObject.transform;

		boxcol.enabled = false;
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
	}


	//design stuff
	private void Designefy()
	{
		switch (DesignValues)
		{
			case 1: FlyAroundInCirclesfunc(); break;
			case 2: GrowAndShrink(); break;
		}
	}

	private void FlyAroundInCirclesfunc()
	{
		InstantObj.AddComponent<FlyAroundInCircles>();
	}

	private void GrowAndShrink()
	{
		InstantObj.AddComponent<GrowAndShrink>();
	}

	//Dev Stuff
	private void Devify()
	{
		switch (DevValues) 
		{
			case 1 : ActivateOnTouch(); break;
            case 2 : ActivateOnNotTouch(); break;
		}
	}

	private void ActivateOnTouch()
	{
		InstantObj.AddComponent<ActivateOnTouch>();
	}

	private void ActivateOnNotTouch()
	{
		InstantObj.AddComponent<ActivateWhenNOTouch>();
	}


}
