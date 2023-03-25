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
            for (int i = 0; i < 20; i++)
            {
                if (Input.GetKeyDown("joystick button " + i))
                {
                    Debug.Log("Joystick Button " + i + " is pressed.");
                }
            }
/*
            if (Input.GetKey(KeyCode.JoystickButton0))
            {
                ActivateMagicObject(Option1Butt);
                Debug.Log("ButtonA");
            }*/
            /*else if (Input.GetButton("ButtonB"))
            {
                ActivateMagicObject(Option2Butt);
                Debug.Log("ButtonB");
            }*/
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
