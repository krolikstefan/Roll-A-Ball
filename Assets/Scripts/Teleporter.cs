using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    //public GameObject teleport2;
    //public GameObject player;
    private Transform player;
    private Transform teleporter2;
    private AudioSource audioToPlay;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        teleporter2 = GameObject.FindGameObjectWithTag("teleport2").transform;
        audioToPlay=GameObject.Find("audioTeleporter").GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {

            StartCoroutine(TeleportAfterDelay());
    }

    IEnumerator TeleportAfterDelay()
    {
        //print("Getting ready to teleport.Wait");
        yield return new WaitForSecondsRealtime(2);
        audioToPlay.Play();
        print("Teleport now");

        player.transform.position = teleporter2.transform.position;
    }


}
