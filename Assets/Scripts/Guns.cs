using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
	public GameObject bullet;
	public Transform firePoint;

	public float StartTimeFire;
	private float TimeFire;

    void Start()
    {
		TimeFire = StartTimeFire;
    }

    void Update()
    {
		if (Input.GetKey(KeyCode.Space))
		{
			if (TimeFire <= 0)
			{
				Instantiate(bullet, firePoint.position, firePoint.rotation);
				TimeFire = StartTimeFire;
			}
			else
			{
				TimeFire -= Time.deltaTime;
			}
		}
    }
}
