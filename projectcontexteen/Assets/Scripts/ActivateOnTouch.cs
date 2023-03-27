using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnTouch : MonoBehaviour
{
	[SerializeField] private GrowAndShrink growandshrink;
	[SerializeField] private FlyAroundInCircles flyaround;
	[SerializeField] private PointOfCreationScript magicalobject;
	[SerializeField] private MagicObjectCollider checkIfPlayerIsInHood;

	private void Awake()
	{
		magicalobject = gameObject.transform.parent.GetComponent<PointOfCreationScript>();
		checkIfPlayerIsInHood = magicalobject.GetComponentInChildren<MagicObjectCollider>();

		flyaround = GetComponent<FlyAroundInCircles>();
		growandshrink = GetComponent<GrowAndShrink>();

		flyaround.STOP = true;
		growandshrink.STOP = true;
	}

	private void Update()
	{
        if (magicalobject.DevValues == 1)
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

        if (magicalobject.DevValues == 2)
        {
            if (magicalobject.DesignValues == 1)
            {
                if (checkIfPlayerIsInHood.PlayerInRange == false)
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
                if (checkIfPlayerIsInHood.PlayerInRange == false)
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
}