using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float JumpHeight;
    public float OverlapSphere;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private LayerMask layerMask;

    private Vector2 movementInput;
    [SerializeField]
    private bool jumped = false;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(movementInput.x * Speed, rb2d.velocity.y);

        if (jumped)
        {
            rb2d.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
	{
        jumped = context.ReadValue<bool>();
        //jumped = context.action.triggered;
	}

	private bool IsGrounded()
	{
        return Physics2D.OverlapCircle(groundCheck.position, OverlapSphere, layerMask);
	}
}

