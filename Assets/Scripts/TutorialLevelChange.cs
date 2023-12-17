using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TutorialLevelChange : MonoBehaviour
{
    public Animator transition;

    public AudioSource endJingle;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        if(Input.GetKeyDown(KeyCode.Escape)) {
            StartCoroutine(LoadLevel(0));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(.5f);

        SceneManager.LoadScene(levelIndex);

    }
}
