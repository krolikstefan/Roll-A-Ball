using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public GameObject player;
    private Transform player;
    private Transform mainCamera;
    //public Camera stageCamera;
    private Vector3 offset;
    // Start is called before the first frame update

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        offset = player.transform.position - mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position = player.transform.position-offset ;
    }
}
