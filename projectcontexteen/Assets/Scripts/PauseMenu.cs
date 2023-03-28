using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public AudioSource audioSource;

    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.JoystickButton7) && Input.GetKey(KeyCode.KeypadMinus))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void PauseFuntionality() // Unused
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7) || Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown("[Escape]"))
        {
            if (!isPaused)
            {
                isPaused = true;
                pauseCanvas.SetActive(true);
                Time.timeScale = 0;
                audioSource.Pause();
            }
            else
            {
                isPaused = false;
                pauseCanvas.SetActive(false);
                Time.timeScale = 1;
                audioSource.Play();
            }
        }
    }
}
