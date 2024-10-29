using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementController : MonoBehaviour
{
    Rigidbody playerRb;
    public float thrust = 6;
    public float jumpStrength = 6; 
    private bool isJumpTrue, isGrounded = true;
    private Vector3 startPosition;
    Vector3 movement;

    // Events
    public event Action pickUpPoint;

    void Start()
    {
        startPosition = transform.position;
        playerRb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("point"))
        {
            pickUpPoint?.Invoke();
        }

        if (other.gameObject.layer == 6)
        {
            transform.position = startPosition;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true; 
            Debug.Log("Landed on ground");
        }
    }

    private void FixedUpdate()
    {
        playerRb.AddForce(movement, ForceMode.Force); 

        if (isJumpTrue)
        {
            playerRb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);  
            isJumpTrue = false; 
            isGrounded = false;  
        }
    }

    private void Update()
    {
        movement = Vector3.zero;  

        if (Input.GetKey(KeyCode.W)) movement += Vector3.forward * thrust;
        if (Input.GetKey(KeyCode.S)) movement += Vector3.back * thrust;
        if (Input.GetKey(KeyCode.A)) movement += Vector3.left * thrust;
        if (Input.GetKey(KeyCode.D)) movement += Vector3.right * thrust;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            isJumpTrue = true; 
            Debug.Log("Jump initiated");
        }
    }
}
