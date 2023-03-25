using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    [SerializeField] private RespawnSystem respawnSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (respawnSystem != null)
            {
                if (collision.name == "Artist") { respawnSystem.Respawn(collision.gameObject, 0); }
                if (collision.name == "Designer") { respawnSystem.Respawn(collision.gameObject, 1); }
                if (collision.name == "Dev") { respawnSystem.Respawn(collision.gameObject, 2); }
            }
        }
    }
}