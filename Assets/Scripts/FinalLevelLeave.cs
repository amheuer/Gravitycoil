using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevelLeave : MonoBehaviour
{
    public Animator transition;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(LoadLevelFast(0));
        }
    }

    IEnumerator LoadLevelFast(int levelIndex)
    {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(.5f);

            SceneManager.LoadScene(levelIndex);
    }
}
