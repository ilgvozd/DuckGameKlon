using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsPlayer2 : MonoBehaviour
{
	public GameObject bullet;
	public Transform BulletTransform;

	public float StartTimeFire;
	private float TimeFire;

	void Start()
	{
		TimeFire = StartTimeFire;
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Alpha0))
		{
			if (TimeFire <= 0)
			{
				Instantiate(bullet, BulletTransform.position, transform.rotation);
				TimeFire = StartTimeFire;
			}
			else
			{
				TimeFire -= Time.deltaTime;
			}
		}
	}
}
