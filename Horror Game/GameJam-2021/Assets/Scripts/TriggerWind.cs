using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWind : MonoBehaviour
{
    AudioSource wind;

    private void Start()
    {
        wind = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            wind.Play();
        }
        else
        {
            wind.Stop();
        }
    }
}
