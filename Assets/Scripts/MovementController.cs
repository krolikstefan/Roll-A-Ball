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
    //private float rotateSpeed = 5;
    

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

        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        if (Input.GetKey(KeyCode.W)) movement += cameraForward * thrust;
        if (Input.GetKey(KeyCode.S)) movement += -cameraForward * thrust;
        if (Input.GetKey(KeyCode.A)) movement += -cameraRight * thrust;
        if (Input.GetKey(KeyCode.D)) movement += cameraRight * thrust;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumpTrue = true;
            isGrounded = false;
            //gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
            playerRb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        }

        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);
        }

    }
}
