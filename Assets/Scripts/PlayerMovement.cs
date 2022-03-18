using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float speed;
	private Rigidbody2D body;
	private Animator anim;
	private bool grounded;

	private void Awake()
	{
		body = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		float horizontalInput = Input.GetAxis("Horizontal");
		body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

		if (Input.GetKey(KeyCode.D)/*horizontalInput > 0.01f*/)
			transform.localScale = new Vector3(19.21291f, 17.9005f, 1.011738f);
		else if (Input.GetKey(KeyCode.A)/*horizontalInput < -0.01f*/)
			transform.localScale = new Vector3(-19.21291f, 17.9005f, 1.011738f);

		if (Input.GetKey(KeyCode.W) && grounded)
			Jump();

		anim.SetBool("run", horizontalInput != 0);
		anim.SetBool("grounded", grounded);
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
