using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] public Rigidbody2D rb;
	[SerializeField] public int damage;
	public float speed;

    private void Start()
    {
		rb.velocity = transform.right * speed;
    }

	private void OnTriggerEnter2D(Collider2D hitInfo)
	{
		PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();

		if (player != null)
		{
			player.TakeDamage(damage);
		}
		Destroy(gameObject);
	}
}
