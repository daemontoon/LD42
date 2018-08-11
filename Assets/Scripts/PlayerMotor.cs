﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerMotor : MonoBehaviour {
    public bool _grounded;
    private Vector2 velocity;
    private Rigidbody2D rb;
    [SerializeField]
    private float maxSpeed, maxSpeedJump, radiusCircle;

    [SerializeField]
    private GameObject GroundCheck;

    [SerializeField]
    private LayerMask layer;

	void Start () {
        velocity = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
	}
	

	void FixedUpdate () {
        PerformRunandJump();
	}
    public void RunAndJump(Vector2 _velocity)
    {
        velocity = _velocity;
    }
    private void PerformRunandJump()
    {
        _grounded = Physics2D.OverlapCircle(GroundCheck.transform.position,radiusCircle , layer);
        if(_grounded)
        {
            rb.AddForce(new Vector2(0f, velocity.y) * Time.deltaTime * maxSpeedJump, ForceMode2D.Impulse);

        }
        rb.velocity = new Vector2(velocity.x * maxSpeed * Time.deltaTime, rb.velocity.y);
    }

}
