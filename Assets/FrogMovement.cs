using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    
    
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform overlapSphereTransform;
    private bool jumpPressed = false;
    private bool onGround = true;
    private bool wPressed = false;
    private bool dPressed = false;
    private bool sPressed = false;
    private bool aPressed = false;
    private Collider[] groundColliders;
    private float firstSpeed;
    private void Start()
    {
         firstSpeed = forwardSpeed;
    }

    private void Update()
    {   
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        } 
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpPressed = false;
        }
        //FORWARD
        if (Input.GetKeyDown(KeyCode.W))
        {
            wPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            wPressed = false;
        }
        //BACKWARD
        if (Input.GetKeyDown(KeyCode.S))
        {
            sPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            sPressed = false;
        }
        //RIGHT
        if (Input.GetKeyDown(KeyCode.D))
        {
            dPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            dPressed = false;
        }
        //LEFT 
        if (Input.GetKeyDown(KeyCode.A))
        {
            aPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            aPressed = false;
        }
    }
    
    void FixedUpdate()
    {
        if (!onGround)
        {
            forwardSpeed = firstSpeed / 3;
        }
        groundColliders = Physics.OverlapSphere(overlapSphereTransform.position, 0.01f, 1<<6);
        if (groundColliders.Length > 0)
        {
            onGround = true;
            forwardSpeed = firstSpeed;
        }
        if (jumpPressed && onGround)
        {
            rigidBody.AddForce(Vector3.up * jumpForce * Time.deltaTime);
            onGround = false;
        }
        //FORWARD
        if (wPressed)
        {
            rigidBody.AddForce(transform.forward * forwardSpeed * Time.deltaTime * 10);
        }
        //BACKWARD
        if (sPressed)
        {
            rigidBody.AddForce( -transform.forward * forwardSpeed * Time.deltaTime * 10);
        }
        //LEFTWARD
        if (aPressed)
        {
            rigidBody.AddForce( -transform.right * forwardSpeed * Time.deltaTime * 10);
        }
        //RIGHTWARD
        if (dPressed)
        {
            rigidBody.AddForce( transform.right * forwardSpeed * Time.deltaTime * 10);
        }
        
    }
}
