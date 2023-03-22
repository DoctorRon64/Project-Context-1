using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Deadline : MonoBehaviour
{
    public float currentTime;
    public float maxTime = 100;

    public GameObject deadlineCanvas;
    public TextMeshProUGUI deadlineTimerText;
    public Slider progressBar;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;
        progressBar.maxValue = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        DepleteTime();
        CheckTime();
        DisplayTimeOnScreen();
    }

    void DepleteTime() // Decrease time over... time!
    {
        currentTime -= Time.deltaTime;
    }

    void CheckTime() // Check if time is over
    {
        if (currentTime <= 0)
        {
            DeadlineHit();
        }
    }

    void DeadlineHit() // Call function when time has hit 0
    {
        StartCoroutine(GameOverProcess());
    }
    IEnumerator GameOverProcess() // Shows cute graphic on screen before fading to black
    {
        deadlineCanvas.GetComponentInChildren<Animator>().SetTrigger("TimesUp");
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("4.GameOver");
    }

    void DisplayTimeOnScreen() // Show the current time on the screen
    {
        deadlineTimerText.text = currentTime.ToString("F1");
        progressBar.value = currentTime;
    }


    public void DecreaseTimeBy(float amount) // Decrease the time by a specific amount instantly
    {
        currentTime -= amount;
    }
}
