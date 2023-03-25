using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float JumpHeight;
    public float OverlapSphere;
    public float FallSpeed;

    public Animator anim;
    public SpriteRenderer sprtRndr;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private LayerMask layerMask;

    public float horizontalInput;
    public string MoveInput;
	public KeyCode UpInput;

    private int Casino;
    private float velocite;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

	private void Update()
	{
        Idle();
        Walking();
        Jumping();
        CasionControls();
        velocite = rb2d.velocity.y;
    }

    void FixedUpdate()
	{
		rb2d.velocity = new Vector2(horizontalInput * Speed, rb2d.velocity.y);

        if (Input.GetKey(UpInput) && IsGrounded())
        {
            rb2d.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
        }
    }

    void Idle()
	{
        if (!Input.GetKey(UpInput) && horizontalInput == 0)
        {
            SetLayerWeights(1, 0, 0);

            anim.SetBool("Walking", false);
        }
    }

    void Walking()
	{
        horizontalInput = Input.GetAxisRaw(MoveInput);

        if (horizontalInput > 0)
        {
            sprtRndr.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            sprtRndr.flipX = true;
        }

        if (horizontalInput > 0 || horizontalInput < 0)
        {
            SetLayerWeights(0, 1, 0);
            anim.SetBool("Walking", true);
        } 
    }

    void Jumping()
	{

        if (velocite != 0)
		{
            AnimationControls();
        }
    }

	private bool IsGrounded()
	{
        return Physics2D.OverlapCircle(groundCheck.position, OverlapSphere, layerMask);
	}

    private void AnimationControls()
	{
        if (rb2d.velocity.y > 0.1)
        {
            SetLayerWeights(0, 0, 1);
            anim.SetBool("GoingUp", true);
            anim.SetBool("Airborne", false);
        }
        else if (rb2d.velocity.y < -0.99)
        {
            SetLayerWeights(0, 0, 1);
            anim.SetBool("GoingUp", false);
            anim.SetBool("Airborne", true);
            rb2d.AddForce(Vector2.down * FallSpeed);
        } else if (rb2d.velocity.y == 0)
		{
            SetLayerWeights(1, 0, 0);
            anim.SetBool("GoingUp", false);
            anim.SetBool("Airborne", false);
        }
    }

    private void CasionControls()
	{
        Casino = Random.Range(0, 2);
        anim.SetInteger("Casino", Casino);
    }

    public void SetLayerWeights(int _layer1, int _layer2, int _layer3)
	{
        anim.SetLayerWeight(0, _layer1);
        anim.SetLayerWeight(1, _layer2);
        anim.SetLayerWeight(2, _layer3);
    }

	
}

