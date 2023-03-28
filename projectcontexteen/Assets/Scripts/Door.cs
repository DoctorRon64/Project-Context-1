using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int playerCount;

    public int playerLayer = 7;

    [SerializeField] bool resetGame;

    Deadline deadline;
    FinalScore finalScore;
    bool foundScoreScript;

    // Start is called before the first frame update
    void Start()
    {
        deadline = FindObjectOfType<Deadline>();
        if (FindObjectOfType<FinalScore>() != null)
        {
            foundScoreScript = true;
            finalScore = FindObjectOfType<FinalScore>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCount == 3)
        {
            if (resetGame)
            {
                SceneManager.LoadScene(3);
            }
            else
            {
                if (foundScoreScript)
                {
                    finalScore.GetFinalTime(deadline.currentTime);
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            playerCount++;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            playerCount--;
        }
    }
}
