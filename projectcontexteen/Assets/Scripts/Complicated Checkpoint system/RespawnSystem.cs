using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSystem : MonoBehaviour
{
    public GameObject[] players;
    public List<GameObject> checkpoints;

    [SerializeField] private Vector2[] startingPositions;
    [SerializeField] private GameObject currentCheckpoint;

    private void Start()
    {
        startingPositions = new Vector2[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            startingPositions[i] = players[i].transform.position;
        }
    }

    public void Respawn(GameObject _player, int _index)
    {
        if (currentCheckpoint != null)
        {
            _player.transform.position = currentCheckpoint.transform.position;
        }
        else
        {
            _player.transform.position = startingPositions[_index];
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