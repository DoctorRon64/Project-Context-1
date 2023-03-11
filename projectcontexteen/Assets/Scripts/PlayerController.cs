using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    public float Speed;
    public float JumpHeight;
    public float OverlapSphere;

    public float horizontalInput;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private LayerMask layerMask;

    void Start()
    {
        if (!IsOwner) return;

        FindObjectOfType<CameraFollow>().GetComponent<CameraFollow>().Target = gameObject;
        if (FindObjectOfType<Camera>().GetComponent<CameraFollow>().Target == null)
		{
            Debug.Log("ERRROORRR !!!1");
            FindObjectOfType<CameraFollow>().GetComponent<CameraFollow>().Target = gameObject;
        }
    }

	public override void OnNetworkSpawn()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!IsOwner) return;

        PlayerInput();
    }

	private void PlayerInput()
	{
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb2d.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
        }

        rb2d.velocity = new Vector2(horizontalInput * Speed, rb2d.velocity.y);
    }

    private bool IsGrounded()
	{
        return Physics2D.OverlapCircle(groundCheck.position, OverlapSphere, layerMask);
	}
}

