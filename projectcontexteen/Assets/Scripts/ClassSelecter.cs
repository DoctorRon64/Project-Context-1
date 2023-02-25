using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassSelecter : MonoBehaviour
{
	public int Choose;
	IsPlayerClass barack;

	private void Awake()
	{
		for (int i = 0; i < 10; i++)
		{
			barack = GetComponent<IsPlayerClass>();
			if (barack.IsLocalPlayer == false)
			{
				barack = GetComponent<IsPlayerClass>();
			}
		}
	}


	public void ArtChoose()
	{
		Choose = 0;
	}

	public void DesignChoose()
	{
		Choose = 1;
	}

	public void DeveloperChoose()
	{
		Choose = 2;
	}
}
