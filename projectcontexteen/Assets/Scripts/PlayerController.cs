using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float JumpHeight;
    public float OverlapSphere;

    public Animator anim;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private LayerMask layerMask;

    public float horizontalInput;
    public string MoveInput;
	public KeyCode UpInput;
    public bool jumped = false;

	void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

	private void Update()
	{
        horizontalInput = Input.GetAxisRaw(MoveInput);
        if (Input.GetKey(UpInput))
		{
            jumped = true;
		} else
		{
            jumped = false;
		}
    }

	void FixedUpdate()
    {
        if (jumped && IsGrounded())
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

