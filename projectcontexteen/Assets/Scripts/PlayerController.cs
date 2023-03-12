using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float JumpHeight;
    public float OverlapSphere;

    public float horizontalInput;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private LayerMask layerMask;

    public KeyCode LeftInput;
    public KeyCode RightInput;
    public KeyCode UpInput;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        PlayerInput();
    }

	private void PlayerInput()
	{
        //horizontalInput = Input.GetAxisRaw("Horizontal");
        


        /*if (Input.GetKeyDown(LeftInput))
		{
            horizontalInput = 1;
		}


        if (Input.GetKeyDown(RightInput))
		{
            horizontalInput = -1;
		}*/

        if (Input.GetKey(UpInput) && IsGrounded())
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

