using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private Transform mainCamera;
    private Vector3 offset;
    private float rotateSpeed = 5;
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

        if(Input.GetMouseButton(0))
        {
            transform.eulerAngles += rotateSpeed * new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"),0);
        }
    }
}
