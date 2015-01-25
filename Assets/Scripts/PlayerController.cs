﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;
	private Animator animator;

	void Start()
	{
		animator = GetComponent<Animator> ();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
				
		animator.SetInteger ("Delta", Mathf.RoundToInt(moveHorizontal));

		rigidbody2D.velocity = new Vector2 (moveHorizontal * speed, rigidbody2D.velocity.y);

		rigidbody2D.AddForce(new Vector2 
		(
			Mathf.Clamp (rigidbody2D.position.x, boundary.xMin, boundary.xMax), 
			0
		), ForceMode2D.Force);
		
		rigidbody2D.rotation = rigidbody2D.velocity.x * tilt;

	}
}
