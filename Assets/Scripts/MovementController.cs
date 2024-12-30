using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementController : MonoBehaviour
{
    Rigidbody playerRb;
    public float thrust = 12;
    public float jumpStrength = 9; 
    private bool isJumpTrue=false, isGrounded = true;
    private Vector3 startPosition;
    Vector3 movement, jump;
    

    // Events
    public event Action pickUpPoint;
    public event Action openDoor;
    public event Action closeDoor;
    public event Action shoutThatYouNeedToOpenTheDoor;
    public event Action iAmOnTheOtherSideDontNeedToOpenTheDoor;

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
        if (other.CompareTag("door"))
        {
            shoutThatYouNeedToOpenTheDoor();
            openDoor?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("door"))
        {
            iAmOnTheOtherSideDontNeedToOpenTheDoor();
            closeDoor?.Invoke();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }

    }

    private void FixedUpdate()
    {
        playerRb.AddForce(movement, ForceMode.Force);

        if (isJumpTrue && isGrounded == false)
        {
            isJumpTrue = false;
            playerRb.AddForce(jump, ForceMode.Impulse);
        }
    }

    private void Update()
    {
        movement = Vector3.zero;  

        if (Input.GetKey(KeyCode.W)) movement += Vector3.forward * thrust;
        if (Input.GetKey(KeyCode.S)) movement += Vector3.back * thrust;
        if (Input.GetKey(KeyCode.A)) movement += Vector3.left * thrust;
        if (Input.GetKey(KeyCode.D)) movement += Vector3.right * thrust;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isJumpTrue = true;
            isGrounded = false;
            gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
            jump = Vector3.up*jumpStrength;


        }
    }
}
