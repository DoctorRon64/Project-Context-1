using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtistKeyInputController : PlayerKeyInputController
{
    [SerializeField] private KeyCode Option3;
    [SerializeField] private Button Option3Button;

	private void Update()
	{
		WhenKeyIsGettingPressed();
	}

	public override void WhenKeyIsGettingPressed()
	{
		base.WhenKeyIsGettingPressed();
		WhenPressedKey(Option3, Option3Button);
	}
}
