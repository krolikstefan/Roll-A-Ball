using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private Transform player;
    private Transform teleporter2;
    private AudioSource audioToPlay;

    public event Action onTeleport;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        teleporter2 = GameObject.FindGameObjectWithTag("teleport2").transform;
        audioToPlay=GameObject.Find("audioTeleporter").GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        onTeleport();
        StartCoroutine(TeleportAfterDelay());
    }

    IEnumerator TeleportAfterDelay()
    {
        yield return new WaitForSecondsRealtime(2);
        audioToPlay.Play();

        player.transform.position = teleporter2.transform.position;
    }


}
