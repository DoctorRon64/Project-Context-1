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

	public GameObject[] ArtistObject;
	public GameObject InstantObj;
	private BoxCollider2D boxcol;
	public GameObject SpriteStuff;

	private bool PlayerInRange;
	[SerializeField] private bool MagicUsed = false;

	private void Awake()
	{
		magicobjecto = GetComponentInChildren<MagicObjectCollider>();
		boxcol = GetComponent<BoxCollider2D>();
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

			CheckifAllTrue();
		}
	}

	public void SetDesign(int _parameter)
	{
		if (PlayerInRange && !MagicUsed)
		{
			DesignValues = _parameter;

			CheckifAllTrue();
		}
	}

	public void SetDev(int _parameter)
	{
		if (PlayerInRange && !MagicUsed)
		{
			DevValues = _parameter;

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
		InstantObj.AddComponent<FlyAroundInCircles>();
		InstantObj.AddComponent<GrowAndShrink>();
	}

	//Dev Stuff
	private void Devify()
	{
		InstantObj.AddComponent<ActivateOnTouch>();
	}
}