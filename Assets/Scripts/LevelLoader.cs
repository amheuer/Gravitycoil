using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;
using static UnityEngine.UI.Selectable;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LevelLoader : MonoBehaviour
{
    public GameObject player;
    public Animator transition;

    public AudioSource endJingle;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(LoadLevelFast(SceneManager.GetActiveScene().buildIndex));
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(LoadLevel(0));
        }
    }
        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }

    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        endJingle.Play();

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelIndex);

    }

    IEnumerator LoadLevelFast(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(.5f);

        SceneManager.LoadScene(levelIndex);

    }

}
