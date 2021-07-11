using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 3f;
  
    public Animator m_Animator;

    //AudioSource passosJogador;

    /*void Start()
    {
        passosJogador = GetComponent<AudioSource>();
    }*/

    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        bool hasHorizontalInput = !Mathf.Approximately(x, 0f);
        bool hasVerticalInput = !Mathf.Approximately(z, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        m_Animator.SetBool("isWalking", isWalking); // ANIMAÇÃO


        /*if (isWalking)
        {
            passosJogador.Play();
        }
        else
        {
            passosJogador.Stop();
        }*/

    }

}
