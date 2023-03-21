using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && Input.GetKey("joystick button 0") && Input.GetKey("[/]"))
        {
            StartTheGame();
        }

        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("E Key pressed");
        }
        if (Input.GetKey("joystick button 0"))
        {
            Debug.Log("A Button pressed");
        }
        if (Input.GetKey("[/]"))
        {
            Debug.Log("Numpad / pressed");
        }
    }

    void StartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
