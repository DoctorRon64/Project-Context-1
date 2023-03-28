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
    private CreateAudioForObject audit;

    private void Awake()
    {
        audit = GetComponent<CreateAudioForObject>();
        magicObjects = AllPOC.GetComponentsInChildren<MagicObjectCollider>();
        usingGamepad = Input.GetJoystickNames().Length > 0;
    }

    private void Update()
    {
        //if (usingGamepad)
        {

            if (Input.GetButtonDown("ButtonB"))
            {
                Debug.Log("ButtonA");
                ActivateMagicObject(Option1Butt);
            }
            else if (Input.GetKeyDown(KeyCode.Pause))
			{
                Debug.Log("ButtonA");
                ActivateMagicObject(Option1Butt);
            }

            if (Input.GetButtonDown("ButtonA"))
			{
                Debug.Log("ButtonB");
                ActivateMagicObject(Option2Butt);
            }
            else if (Input.GetKeyDown(KeyCode.End))
			{
                Debug.Log("ButtonB");
                ActivateMagicObject(Option2Butt);
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
                audit.PlayAudio(0);
            }
        }
    }
}
