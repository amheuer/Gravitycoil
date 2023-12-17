using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;
using static UnityEngine.UI.Selectable;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class OnClickLevelChange : MonoBehaviour
{
    public Animator transition;
    public int destination;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(LoadLevelFast(0));
        }

    }
    public void LoadLevelFastCall()
    {
        StartCoroutine(LoadLevelFast(destination));
    }


    IEnumerator LoadLevelFast(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(.5f);

        SceneManager.LoadScene(levelIndex);

    }
    public void ExitGame()
    {
        StartCoroutine(LoadLevelFast(2));
        //#if UNITY_EDITOR
        //EditorApplication.ExitPlaymode();
        //#else
        //   Application.Quit();
        //    ProgressManager.Instance.SavePoint(); 
        //#endif
    }
}
