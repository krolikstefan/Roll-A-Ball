using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Camera stageCamera;
    private Vector3 offset;
    // Start is called before the first frame update

    void Start()
    {

        offset = player.transform.position - stageCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        stageCamera.transform.position = player.transform.position-offset ;
    }
}
