using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private List<Transform> doors = new List<Transform>();
    private float speed = 2f;
    private Dictionary<Transform, float> minYs = new Dictionary<Transform, float>();
    private Dictionary<Transform, float> maxYs = new Dictionary<Transform, float>();
    private bool isOpening = false;
    private bool isClosing = false;
    private bool isCloseToADoor = false;

    private GameObject player;
    private MovementController controller;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<MovementController>();
        GameObject[] doorObjects = GameObject.FindGameObjectsWithTag("door");

        foreach (GameObject doorObject in doorObjects)
        {
            Transform doorTransform = doorObject.transform;
            doors.Add(doorTransform);

            float minY = doorTransform.position.y;
            float maxY = minY + 10f;

            minYs[doorTransform] = minY;
            maxYs[doorTransform] = maxY;
        } 

        controller.shoutThatYouNeedToOpenTheDoor += openTheDoorPlease;
        controller.iAmOnTheOtherSideDontNeedToOpenTheDoor += dontOpenTheDoorPlease;

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F)&&isCloseToADoor==true)
        {
            isOpening = true;
        }

        if (isOpening || isClosing)
        {
            MoveDoors();
        }
    }

    IEnumerator CloseDoorsAfterDelay()
    {
        yield return new WaitForSecondsRealtime(2);
        isClosing = true;
    }

    void MoveDoors()
    {
        float step = speed * Time.deltaTime;

        foreach (Transform door in doors)
        {
            Vector3 position = door.position;

            if (isOpening)
            {
                position.y += step;
                if (position.y >= maxYs[door])
                {
                    position.y = maxYs[door];
                    isOpening = false;
                    StartCoroutine(CloseDoorsAfterDelay());
                }
            }

            if (isClosing)
            {
                position.y -= step;
                if (position.y <= minYs[door])
                {
                    position.y = minYs[door];
                    isClosing = false;
                }
            }

            door.position = position;
        }
    }
    private void openTheDoorPlease()
    {
        isCloseToADoor = true;
    }
    private void dontOpenTheDoorPlease()
    {
        isCloseToADoor = false;
    }

}
