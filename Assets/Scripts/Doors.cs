using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject door;
    public float speed = 2f;
    private float minY, maxY;
    private bool isOpening = false;
    private bool isClosing = false;

    void Start()
    {
        minY = door.transform.position.y;
        maxY = door.transform.position.y + 10f;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            isOpening = true;
        }

        if (isOpening || isClosing)
        {
            MoveDoor();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("press F to open the door");
    }

    IEnumerator CloseDoorsAfterDelay()
    {
        yield return new WaitForSecondsRealtime(3);
        isClosing = true;
    }

    void MoveDoor()
    {
 
        Vector3 position = door.transform.position;
        float step = speed * Time.deltaTime;

        if (isOpening)
        {
            position.y += step;
            if (position.y >= maxY)
            {
                position.y = maxY;
                isOpening = false;
                StartCoroutine(CloseDoorsAfterDelay());
            }
        }

        if (isClosing)
        {
            position.y -= step;
            if (position.y <= minY)
            {
                position.y = minY;
                isClosing = false;
            }
        }

        door.transform.position = position;
    }
}
