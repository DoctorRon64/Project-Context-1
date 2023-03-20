using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnTouch : MonoBehaviour
{
	[SerializeField] private GrowAndShrink growandshrink;
	[SerializeField] private FlyAroundInCircles flyaround;
	[SerializeField] private MagicObjectBehaviour magicalobject;
	[SerializeField] private MagicObject checkIfPlayerIsInHood;

	private void Awake()
	{
		magicalobject = gameObject.transform.parent.GetComponent<MagicObjectBehaviour>();
		checkIfPlayerIsInHood = magicalobject.GetComponentInChildren<MagicObject>();

		flyaround = GetComponent<FlyAroundInCircles>();
		growandshrink = GetComponent<GrowAndShrink>();

		flyaround.STOP = true;
		growandshrink.STOP = true;
	}

	private void Update()
	{
		if (magicalobject.DesignValues == 1)
		{
			if (checkIfPlayerIsInHood.PlayerInRange == true)
			{
				flyaround.STOP = false;
				growandshrink.STOP = true;
			} 
			else
			{
				flyaround.STOP = true;
				growandshrink.STOP = true;
			}
		}

		if (magicalobject.DesignValues == 2)
		{
			if (checkIfPlayerIsInHood.PlayerInRange == true)
			{
				flyaround.STOP = true;
				growandshrink.STOP = false;
			}
			else
			{
				flyaround.STOP = true;
				growandshrink.STOP = true;
			}
		}
	}
}	
