using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerKeyInputController : MonoBehaviour
{
    [SerializeField] protected KeyCode Option1;
    [SerializeField] protected KeyCode Option2;

	protected MagicObjectCollider[] MagicObjects = new MagicObjectCollider[5];
	[SerializeField] protected Button Option1Button, Option2Button;
	[SerializeField] protected GameObject AllPOCs;
	private CreateAudioForObject audit;

	private void Awake()
	{
		audit = GetComponent<CreateAudioForObject>();
		MagicObjects = AllPOCs.GetComponentsInChildren<MagicObjectCollider>();
	}

	private void Update()
	{
		WhenKeyIsGettingPressed();
	}

	public virtual void WhenKeyIsGettingPressed()
	{
		WhenPressedKey(Option1, Option1Button);
		WhenPressedKey(Option2, Option2Button);
	}


	public void WhenPressedKey(KeyCode _optionkey, Button _button)
	{
		if (Input.GetKeyDown(_optionkey))
		{
			for (int i = 0; i < MagicObjects.Length; i++)
			{
				if (MagicObjects[i].PlayerInRange == true)
				{
					_button?.onClick.Invoke();
					Debug.Log(_optionkey);
					audit.PlayAudio(0);
				}
			}
		}
	}

	
}
