using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.UI;
using TMPro;

public class MagicObjectBehaviour : MagicObject
{
	public override void SetArt1()
	{
		Instantiate(ArtistObject[0]);
		gameObject.SetActive(false);
		SetValue[0] = false;
	}

	public override void SetArt2()
	{
		Instantiate(ArtistObject[1]);
		gameObject.SetActive(false);
		SetValue[0] = false;
	}

	public override void SetArt3()
	{
		Instantiate(ArtistObject[2]);
		gameObject.SetActive(false);
		SetValue[0] = false;
	}

	public override void SetDesign1()
	{
		SetValue[1] = false;
	}

	public override void SetDesign2()
	{
		SetValue[1] = false;
	}

	public override void SetDesign3()
	{
		SetValue[1] = false;
	}

	public override void SetDev1()
	{
		SetValue[2] = false;
	}

	public override void SetDev2()
	{
		SetValue[2] = false;
	}

	public override void SetDev3()
	{
		SetValue[2] = false;
	}


}
