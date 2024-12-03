using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private List<Transform> doors = new List<Transform>();
    private float speed = 2f;
    private Dictionary<Transform, float> minYs = new Dictionary<Transform, float>();
    private Dictionary<Transform, float> maxYs = new Dictionary<Transform, float>();
    private bool isMoving = false; 
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

        controller.shoutThatYouNeedToOpenTheDoor += OpenTheDoorPlease;
        controller.iAmOnTheOtherSideDontNeedToOpenTheDoor += DontOpenTheDoorPlease;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && isCloseToADoor && !isMoving)
        {
            StartCoroutine(OpenAndCloseDoor());
        }
    }

    IEnumerator OpenAndCloseDoor()
    {
        isMoving = true;

        yield return MoveDoors(true);


        yield return new WaitForSecondsRealtime(1);
        yield return MoveDoors(false);

        isMoving = false;
    }

    IEnumerator MoveDoors(bool opening)
    {
        float step = speed * Time.deltaTime;

        while (true)
        {
            bool allDoorsReachedTarget = true;

            foreach (Transform door in doors)
            {
                Vector3 position = door.position;

                if (opening)
                {
                    position.y += step;
                    if (position.y < maxYs[door])
                    {
                        allDoorsReachedTarget = false;
                    }
                    else
                    {
                        position.y = maxYs[door];
                    }
                }
                else
                {
                    position.y -= step;
                    if (position.y > minYs[door])
                    {
                        allDoorsReachedTarget = false;
                    }
                    else
                    {
                        position.y = minYs[door];
                    }
                }

                door.position = position;
            }

            if (allDoorsReachedTarget)
                break;

            yield return null;
        }
    }

    private void OpenTheDoorPlease()
    {
        isCloseToADoor = true;
    }

    private void DontOpenTheDoorPlease()
    {
        isCloseToADoor = false;
    }
}
