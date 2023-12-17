using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NameLevelLoad : MonoBehaviour
{
    public string levelName;
    public Animator transition;

    public void LoadName()
    {
        StartCoroutine(LoadLevelFast(levelName));
    }

    IEnumerator LoadLevelFast(string levelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(.5f);

        SceneManager.LoadScene(levelName);
    }
}
