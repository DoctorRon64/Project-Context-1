using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    public float Speed;
	private Rigidbody2D Rigidbody2D;
    

	void Awake()
    {
        if (!IsOwner) return;

        Camera.main.GetComponent<CameraFollow>().Target = gameObject;
        Camera.main.GetComponent<CameraFollow>().enabled = true;
    }

    public override void OnNetworkSpawn()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;

        transform.position += new Vector3(1, 0) * Input.GetAxis("Horizontal") * Time.deltaTime;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Rigidbody2D.AddForce(Speed * Time.deltaTime * new Vector2(horizontalInput, verticalInput) * Time.deltaTime * Speed);
    }

    

}
