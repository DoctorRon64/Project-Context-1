using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllignPlayerWhenFlight : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = new Vector3(gameObject.transform.position.x, 0, 0);
        }
    }

}
