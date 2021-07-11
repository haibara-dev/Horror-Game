using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerTutorial : MonoBehaviour
{
    public Text textoVela;
    private GameObject jogador;
    [Range(0.5f, 5f)] public float distancia = 1.5f;



    void Start()
    {
        textoVela.enabled = false;
        jogador = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, jogador.transform.position) < distancia)
        {
            textoVela.enabled = true;
        }
        else if (PickUpController.velaNaMao)
        {
            textoVela.enabled = false;
        }
        else
        {
            textoVela.enabled = false;
        }
       
    }
}
