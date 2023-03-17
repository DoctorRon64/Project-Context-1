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

    public AnimationCurve layerWeightCurve;
    public float horizontalInput;
    public string MoveInput;
	public KeyCode UpInput;
    public bool jumped = false;
    public bool jumpeded = false;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

	private void Update()
	{
        Walking();
        Idle();
        Jumping();

        anim.SetInteger("Casino", 1);
        anim.SetInteger("Casino", 0);
    }

    void FixedUpdate()
	{
		rb2d.velocity = new Vector2(horizontalInput * Speed, rb2d.velocity.y);
        if (jumped && IsGrounded())
        {
            rb2d.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
            AnimationControls();
        }
        jumpeded = IsGrounded();
    }

    void Idle()
	{
        if (jumped == false && horizontalInput == 0)
        {
            anim.SetLayerWeight(0, 0);
        }
    }

    void Walking()
	{
        horizontalInput = Input.GetAxisRaw(MoveInput); 

        if (horizontalInput > 0)
        {
            anim.SetLayerWeight(1, 0);
            anim.SetBool("Walking", true);
        } 
        else if (horizontalInput < 0)
		{
            anim.SetLayerWeight(0, 0);
            anim.SetBool("Walking", false);
        }
    }

    void Jumping()
	{
        if (Input.GetKey(UpInput)) { 
            jumped = true;
        } else { 
            jumped = false;
        }
    }

	private bool IsGrounded()
	{
        return Physics2D.OverlapCircle(groundCheck.position, OverlapSphere, layerMask);
	}

    private void AnimationControls()
	{
        if (rb2d.velocity.y < 0)
		{
            float curveWeight = rb2d.velocity.y;
            curveWeight = Mathf.Abs(curveWeight);
            curveWeight /= 40;
            curveWeight = Mathf.Clamp(curveWeight, 0, 1);
            anim.SetLayerWeight(2, layerWeightCurve.Evaluate(curveWeight));

            anim.SetBool("GoingUp", false);
            anim.SetBool("Airborne", true);
        }
        else
		{
            anim.SetLayerWeight(2, 0);
            anim.SetBool("GoingUp", true);
            anim.SetBool("Airborne", false);
        }
	}
}

