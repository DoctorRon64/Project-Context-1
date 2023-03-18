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
	public GameObject SpriteStuff;

	[SerializeField]
	private bool PlayerInRange = false;

	private void Awake()
	{
		magicobjecto = GetComponent<MagicObject>();
		boxcol = GetComponent<BoxCollider2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			PlayerInRange = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			PlayerInRange = false;
		}
	}

	//check stuff
	public void SetArt(int _parameter)
	{
		if (PlayerInRange)
		{
			ArtValues = _parameter;

			CheckifAllTrue();
		}
	}

	public void SetDesign(int _parameter)
	{
		if (PlayerInRange)
		{
			DesignValues = _parameter;

			CheckifAllTrue();
		}
	}

	public void SetDev(int _parameter)
	{
		if (PlayerInRange)
		{
			DevValues = _parameter;

			CheckifAllTrue();
		}
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
		SpriteStuff.SetActive(false);
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
