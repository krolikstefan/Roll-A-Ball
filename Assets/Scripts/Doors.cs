using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject player;
    public GameObject door; //how to difference them?
    private bool isDoorReadyToOpen=false;
    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) {
        isDoorReadyToOpen = true;

            if (isDoorReadyToOpen)
            {
                Vector3 v = new Vector3(0, 10, 0);
                door.transform.position += v;
                isDoorReadyToOpen = false; //to do: fix the doors; wait and then close???
            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("press F to open the door");
    }
}
