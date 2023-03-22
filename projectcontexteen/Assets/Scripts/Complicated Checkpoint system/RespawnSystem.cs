using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSystem : MonoBehaviour
{
    public GameObject[] players;
    public List<GameObject> checkpoints;

    private Vector2[] startingPositions;
    private GameObject currentCheckpoint;

    private void Start()
    {
        startingPositions = new Vector2[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            startingPositions[i] = players[i].transform.position;
        }
    }

    public void Respawn()
    {
        if (currentCheckpoint != null)
        {
            foreach (GameObject player in players)
            {
                player.transform.position = currentCheckpoint.transform.position;
            }
        }
        else
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].transform.position = startingPositions[i];
            }
        }
    }

    public void UpdateCheckpoint(GameObject newCheckpoint)
    {
        if (!checkpoints.Contains(newCheckpoint))
        {
            checkpoints.Add(newCheckpoint);
        }
        currentCheckpoint = newCheckpoint;
    }

    public bool PlayerInRangeOfCheckpoint(GameObject player)
    {
        if (currentCheckpoint == null)
        {
            return false;
        }
        float distance = Vector2.Distance(player.transform.position, currentCheckpoint.transform.position);
        return distance <= currentCheckpoint.GetComponent<Checkpoint>().checkpointRange;
    }
}