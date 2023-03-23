using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAroundInCircles : MonoBehaviour
{
    public flyindexitem[] IndexToMoveTo = new flyindexitem[4];
    public int FlyIndex = 0;
	public int speed = 5;

	public bool STOP;

	// Update is called once per frame
	private void Start()
	{
		getIndexesFlying();
	}

	private void Update()
	{
		if (FlyIndex >= 4)
		{
			FlyIndex = 0;
		}

		if (!STOP)
		{
			transform.position = Vector2.MoveTowards(transform.position, IndexToMoveTo[FlyIndex].transform.position, Time.deltaTime * speed);
		}

		if (Vector2.Distance(transform.position, IndexToMoveTo[FlyIndex].transform.position) < 0.5f)
		{
			FlyIndex++;
		}
	}

	private void getIndexesFlying()
	{
		Transform parent = gameObject.transform.parent;
		for (int i = 0; i < IndexToMoveTo.Length; i++)
		{
			IndexToMoveTo[i] = parent.GetChild(i).GetComponent<flyindexitem>();
		}
	}
}