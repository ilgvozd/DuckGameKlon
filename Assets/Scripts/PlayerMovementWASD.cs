using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWASD : MonoBehaviour
{
	[SerializeField] private float speed;
	private Rigidbody2D body;
	private Animator anim;

	bool isFacingRight = true;
	private bool grounded;

	private void Awake()
	{
		body = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	private void FixedUpdate()
	{
		Run();
	}

	public void Run()
	{
		float move = Input.GetAxis("HorizontalWASD");
		anim.SetFloat("Speed", Mathf.Abs(move));

		body.velocity = new Vector2(move * speed, body.velocity.y);

		if (move > 0 && !isFacingRight)
			Flip();
		else if (move < 0 && isFacingRight)
			Flip();

		if (Input.GetKey(KeyCode.W) && grounded)
			Jump();

		anim.SetBool("run", move != 0);
		anim.SetBool("grounded", grounded);
	}

	void Flip()
	{
		isFacingRight = !isFacingRight;
		transform.Rotate(0f, 180f, 0f);
	}

	private void Jump()
	{
		body.velocity = new Vector2(body.velocity.x, speed);
		grounded = false;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
			grounded = true;
	}
}
