using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAroundInCircles : MonoBehaviour
{
    public flyindexitem[] IndexToMoveTo = new flyindexitem[4];
    public int FlyIndex = 0;
	public int cooldown = 1;

	// Update is called once per frame
	private void Start()
	{
		FlyAroundInCirclesCallon();

		IndexToMoveTo = FindObjectsOfType<flyindexitem>();
	}

	private void Update()
	{
		transform.position = Vector2.MoveTowards(transform.position, IndexToMoveTo[FlyIndex].transform.position, Mathf.Infinity);
	}

	private void FlyAroundInCirclesCallon()
	{
		IndexToMoveTo = FindObjectsOfType<flyindexitem>();

		if (FlyIndex >= 4)
		{
			FlyIndex = 0;
		}
		StartCoroutine(WaitForNewFlyIndex());
	}

	IEnumerator WaitForNewFlyIndex()
	{
		yield return new WaitForSeconds(cooldown);
		FlyIndex++;
		FlyAroundInCirclesCallon();
	}
}
