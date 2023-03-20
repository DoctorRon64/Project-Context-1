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

	private bool PlayerInRange;

	private void Awake()
	{
		magicobjecto = GetComponentInChildren<MagicObject>();
		boxcol = GetComponent<BoxCollider2D>();
	}

	private void Update()
	{
		PlayerInRange = magicobjecto.PlayerInRange;
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
		InstantObj.AddComponent<FlyAroundInCircles>();
		InstantObj.AddComponent<GrowAndShrink>();
	}

	//Dev Stuff
	private void Devify()
	{
		InstantObj.AddComponent<ActivateOnTouch>();
	}
}
