using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTransition : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;


    public void PlayButton()
    {
        LoadNextLevel();
    }

    public void ExitButton()
    {
        Application.Quit();
        // Sound Effect
        GetComponent<AudioSource>().Play();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Sound Effect
        GetComponent<AudioSource>().Play();

        // Play animation
        transition.SetTrigger("Start");

        // Wait
        yield return new WaitForSeconds(transitionTime);

        // Load Scene
        SceneManager.LoadScene(levelIndex);
    }
}
