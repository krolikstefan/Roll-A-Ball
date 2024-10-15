using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MovementController : MonoBehaviour
{

    Rigidbody playerRb;
    public float thrust = 5;
    public int score = 0;
    public int scoreToGet;
    private bool wPressed, sPressed, aPressed, dPressed;
    Vector3 movement;

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
            score++;
            print("Your score: " + score);
            scoreToGet--;
        }
        else if (scoreToGet <= 0)
        {
            print("You win!");
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
    }
    void FixedUpdate()
    {
        playerRb.AddForce(movement);
    }
}
