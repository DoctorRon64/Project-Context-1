using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerKeyInputDesign : MonoBehaviour
{
    public Button Option1Butt;
    public Button Option2Butt;

    private MagicObjectCollider[] magicObjects;
    [SerializeField] private GameObject AllPOC;
    private bool usingGamepad;

    private void Awake()
    {
        magicObjects = AllPOC.GetComponentsInChildren<MagicObjectCollider>();
        usingGamepad = Input.GetJoystickNames().Length > 0;
    }

    private void Update()
    {
        if (usingGamepad)
        {

            if (Input.GetButtonDown("ButtonA"))
            {
                Debug.Log("ButtonA");
                ActivateMagicObject(Option1Butt);
            }
            else if (Input.GetKeyDown(KeyCode.Joystick1Button0))
			{
                Debug.Log("ButtonA");
            }

			if (Input.GetButtonDown("ButtonB"))
			{
                Debug.Log("ButtonB");
                ActivateMagicObject(Option2Butt);
			}
            else if (Input.GetKeyDown(KeyCode.Joystick1Button1))
			{
                Debug.Log("ButtonB");
            }

        }
    }

    private void ActivateMagicObject(Button _button)
    {
        foreach (MagicObjectCollider magicObject in magicObjects)
        {
            if (magicObject.PlayerInRange)
            {
                _button?.onClick.Invoke();
            }
        }
    }
}
