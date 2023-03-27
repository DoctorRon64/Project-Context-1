using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public KeyCode InputA;
    public KeyCode InputC;

	// Update is called once per frame
	void Update()
    {
        if (Input.GetKey(InputA) && Input.GetButtonDown("ButtonB") && Input.GetKey(InputC))
        {
            StartTheGame();
        }

        if (Input.GetKey(InputA))
        {
            Debug.Log("E Key pressed");
        }
        if (Input.GetButtonDown("ButtonB"))
        {
            Debug.Log("ButtonA");
        }
        if (Input.GetKey(InputC))
        {
            Debug.Log("Numpad / pressed");
        }
    }

    void StartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
