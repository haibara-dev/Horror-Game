using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public Rigidbody rb;
    public Collider coll;
    public Transform player, camera, lugarVela;
    public float pickUpRange;

    public static bool velaNaMao = false;

    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;

        if (distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E))
        {
            PegouVela();
            velaNaMao = true;
        }


    }

    private void PegouVela()
    {
        GetComponent<AudioSource>().Play();
        rb.isKinematic = true;
        coll.isTrigger = true;
        
        transform.SetParent(lugarVela);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
    }


}
