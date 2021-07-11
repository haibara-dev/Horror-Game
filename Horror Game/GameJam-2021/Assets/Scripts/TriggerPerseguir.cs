using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPerseguir : MonoBehaviour
{

    public AudioSource perseguir;

    void Start()
    {
        perseguir = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StalkerClown.prontoPraAtacar = true;
            perseguir.Play();
        }
    }
}
