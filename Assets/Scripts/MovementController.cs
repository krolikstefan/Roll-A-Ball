using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MovementController : MonoBehaviour
{

    Rigidbody playerRb;
    public float thrust = 6;
    public float jumpStrength = 0;
    private int score = 0;
    private int scoreToGet;
    private bool isJumpTrue, isGrounded = true;
    Vector3 movement,jump;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        scoreToGet = GameObject.FindGameObjectsWithTag("point").Length;
        print("Score to get: "+scoreToGet);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "point" && scoreToGet>0)
        {
            score+=1;
            scoreToGet -= 1;
            print("Your score: " + score + " Points left: "+scoreToGet);
        }
        if (scoreToGet == 0 && collision.gameObject.tag=="point")
        {
            print("-----------------------------");
            print("Win!");
            print("-----------------------------");
        }
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }

    }



    private void Update()
    {
        movement = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            movement = new Vector3(0, 0, thrust);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement = new Vector3(0, 0, -thrust);
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement = new Vector3(-thrust, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement = new Vector3(thrust, 0 , 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            jump = new Vector3(0, jumpStrength, 0);
            isJumpTrue = true;
        }
        
    }
    private void FixedUpdate()
    {

        playerRb.AddForce(movement);

        
        if(isJumpTrue) {
            playerRb.AddForce(jump, ForceMode.Impulse);
            isJumpTrue = false;
            isGrounded = false;
        }
    }


}
