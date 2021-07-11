using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoors : MonoBehaviour
{
    public Rigidbody rb;
    public Collider coll;
    public Transform player, camera, lugarChave;
    public float pickUpRange;

    public AudioSource pegou;

    public static bool estaComChave;

    void Start()
    {
        pegou = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;

        if (distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E))
        {
            PegouVela();
            estaComChave = true;
        }

    }

    private void PegouVela()
    {
        rb.isKinematic = true;
        coll.isTrigger = true;

        pegou.Play();
        transform.SetParent(lugarChave);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
    }

}
