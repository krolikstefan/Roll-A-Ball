using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovementController : MonoBehaviour
{

    Rigidbody playerRb;
    public float thrust = 6;
    public float jumpStrength = 0;
    private int score = 0;
    private int scoreToGet;
    private bool isJumpTrue, isGrounded = true;
    private Vector3 startPosition;
    public Text scoreText;
    public Text infoText;
    Vector3 movement,jump;

    // Start is called before the first frame update
    void Start()
    {
        startPosition= gameObject.transform.position;
        playerRb = GetComponent<Rigidbody>();
        scoreToGet = GameObject.FindGameObjectsWithTag("point").Length;
        print("Score to get: "+scoreToGet);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "point" && scoreToGet > 0)
        {
            score += 1;
            scoreToGet -= 1;
            scoreText.text = "Score: " + score;
        }
        if (scoreToGet == 0 && other.gameObject.tag == "point")
        {
            //infoText.text = "You Won c: Wait for the next stage!";
            StartCoroutine(NextStage());
        }

        if (other.gameObject.layer == 6)
        {
            //StartCoroutine(Reload());
            transform.position = startPosition;
            //infoText.text = "Oops, start again";
        }
        if (other.gameObject.tag == "door")
        {
            infoText.text = "Press F to open a door";
            
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
            infoText.text = " ";
    }
    IEnumerator NextStage()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(1);
    }
    //IEnumerator Reload()
    //{
    //    transform.position = startPosition;
    //    infoText.text = "Oops, start again";
    //    yield return new WaitForSecondsRealtime(3);
    //}

    private void OnCollisionEnter(Collision collision)
    {
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
