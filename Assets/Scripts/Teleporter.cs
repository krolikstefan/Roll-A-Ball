using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public GameObject teleport2;
    public GameObject player;



    private void OnCollisionEnter(Collision collision)
    {

            StartCoroutine(TeleportAfterDelay());
    }

    IEnumerator TeleportAfterDelay()
    {
        print("Getting ready to teleport.Wait");
        yield return new WaitForSecondsRealtime(2);
        print("Teleport now");

        player.transform.position = teleport2.transform.position;
    }


}
