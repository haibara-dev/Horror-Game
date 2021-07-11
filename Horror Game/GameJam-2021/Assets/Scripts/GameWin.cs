using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    //public float fadeDuration = 1f;
    public GameObject player;
    bool isPlayerExit = false;

    // Elementos de transição de tela 
    public float transitionTime = 5f;
    public Animator winTransition;

    public AudioSource winLevel; // audio
    public AudioSource trancado;

    void Update()
    {
        if (isPlayerExit)
        {
            LoadEnding();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && KeyDoors.estaComChave)
        {
            isPlayerExit = true;
            winLevel.Play();
        }

        if (other.gameObject == player && KeyDoors.estaComChave == false)
        {
            trancado.GetComponent<AudioSource>().Play();
        }
    }

    public void LoadEnding()
    {
        StartCoroutine(LoadLevel()); 
    }

    IEnumerator LoadLevel()
    {
        // Play animation
        winTransition.GetComponent<Animator>().Play("FadeWin");
        yield return new WaitForSeconds(transitionTime);

        Application.Quit();
        // Load Scene
        //SceneManager.LoadScene("InitialScreen");
    }
}
