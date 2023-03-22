using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private RespawnSystem respawnSystem;
    public float checkpointRange = 1f;
    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !activated)
        {
            if (respawnSystem != null)
            {
                respawnSystem.UpdateCheckpoint(gameObject);
                activated = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, checkpointRange);
    }
}