﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrlScript : MonoBehaviour {

    [SerializeField] private float acceleration;
    [SerializeField] private float jumpPower;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Collider background;

    [HideInInspector] public bool isTurnning = false;
    [HideInInspector] public bool isJumping = false;
    private Animator animator = null;
    private float time = 0;
    private float defaultX;

    private Rigidbody thisRig;

	void Start () {
        thisRig = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
	}
	
	void Update ()
    {
        Move();
        Gravity();
    }

    void Move()
    {
        transform.Translate(Time.deltaTime * moveSpeed, 0, 0);
    }

    void Gravity()
    {
        if (isJumping && !isTurnning)
        {
            time += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, (-acceleration / 2) * time * time + jumpPower * time + defaultX, transform.position.z);
        }
        //else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width/2 && Input.mousePosition.x < Screen.height / 2)
        else if(Input.GetMouseButtonDown(0))
        {
            thisRig.useGravity = false;
            time = 0;
            isJumping = true;
            defaultX = transform.position.y;
            animator.SetTrigger("jump");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("background"))
        {
            thisRig.useGravity = true;
            isJumping = false;
        }
    }

}
