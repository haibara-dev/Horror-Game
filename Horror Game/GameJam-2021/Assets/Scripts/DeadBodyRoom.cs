using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBodyRoom : MonoBehaviour
{
    AudioSource deadBodyRoom;

    private void Start()
    {
        deadBodyRoom = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            deadBodyRoom.Play();
        }
    }
}
