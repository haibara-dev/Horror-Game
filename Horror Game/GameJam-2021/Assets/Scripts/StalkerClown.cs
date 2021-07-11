using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StalkerClown : MonoBehaviour
{

    NavMeshAgent stalkerAgent;

    // ATAQUE
    public LayerMask whatIsPlayer;
    public float attackRange, sightRange;
    public bool playerInAttackRange, playerInSightRange;
   
    // MORTE
    public static bool prontoPraAtacar;
    AudioSource socou;

    // PERSEGUIR
    public GameObject jogador;
    //public static bool isStalking;

    // PATRULHAR
    public Transform[] pontosDestino;
    Transform currentPoint;

    // ANIMAÇÃO
    public GameObject clown;
    public GameObject loseCanvas;

    void Start()
    {
        stalkerAgent = GetComponent<NavMeshAgent>();
        socou = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !prontoPraAtacar)
        {
            Patrulhar();
        }
        if (playerInSightRange && !prontoPraAtacar)
        {
            Perseguir();
        }
        if (prontoPraAtacar && playerInSightRange)
        {
            Atacar();
        }

    }

    void Patrulhar()
    {
        if (currentPoint == null)
        {
            currentPoint = DestinoAleatorio();
        }
        else if (Vector3.Distance(transform.position, currentPoint.position) < 1)
        {
            currentPoint = DestinoAleatorio();
        }
        clown.GetComponent<Animator>().Play("WalkClown");
        stalkerAgent.SetDestination(currentPoint.position);
    } 

    void Perseguir()
    {
            clown.GetComponent<Animator>().Play("WalkClown");
            stalkerAgent.SetDestination(jogador.transform.position);    
    }

    void Atacar()
    {
        StartCoroutine(Matou());  
    }

    IEnumerator Matou()
    {
        clown.GetComponent<Animator>().Play("Zombie Punching");
        socou.Play();
        transform.LookAt(jogador.transform);

        loseCanvas.GetComponent<Animator>().Play("FadeLose");
        yield return new WaitForSeconds(2f);

        Application.Quit();
    }

    Transform DestinoAleatorio()
    {
        var indice = Random.Range(0, pontosDestino.Length);
        return pontosDestino[indice];
    }


}
