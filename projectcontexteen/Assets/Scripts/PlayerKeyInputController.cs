using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerKeyInputController : MonoBehaviour
{
    [SerializeField] private KeyCode Option1;
    [SerializeField] private KeyCode Option2;

	[SerializeField] private MagicObjectCollider[] MagicObjects = new MagicObjectCollider[5];
	[SerializeField] private Button Option1Button, Option2Button;

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
		if (Input.GetKey(_optionkey))
		{
			for (int i = 0; i < MagicObjects.Length; i++)
			{
				if (MagicObjects[i].PlayerInRange == true)
				{
					_button?.onClick.Invoke();
					Debug.Log("jo");
				}
			}
		}
	}
}
