using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    AudioSource m_audioSource;
    void Start()
    {
        m_audioSource = GameObject.Find("playSoundOnPoint").GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate(90.0f * Time.deltaTime, 0.0f, 0.0f, Space.Self);


    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        m_audioSource.Play();

    }
}
