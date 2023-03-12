using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.UI;

public class DeadlineFinish : MonoBehaviour
{
	//public Text TimerText;
	public int SetTime;
	public int CurrentTime;
	public bool IsStart;

	public void Start()
	{
		
	}

	public void Update()
	{
		if (!IsStart)
		{
			CurrentTime = SetTime;
		}

		if (IsStart)
		{
			int Subtraction = Mathf.RoundToInt(Time.deltaTime); 
			CurrentTime -= Subtraction;
		}
	}
}
