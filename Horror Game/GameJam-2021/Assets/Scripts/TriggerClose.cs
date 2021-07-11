using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerClose : MonoBehaviour
{
    public AudioSource closeToPlayer;

    void Start()
    {
        closeToPlayer = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            closeToPlayer.Play();
        }
    }
}
