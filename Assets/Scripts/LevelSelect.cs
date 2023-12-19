using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;
using static UnityEngine.UI.Selectable;
using UnityEngine.UI;
using UnityEditor.Rendering;
using System.Runtime.InteropServices;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LevelSelect : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void StartGameEvent();

    public Animator transition;
    public int destination;

    public Image image;
    public Sprite blackSprite;
    public Sprite graySprite;

    public void Update()
    {

        if (ProgressManager.Instance.furthestPoint >= destination || destination == 6)
        {
            image.sprite = graySprite;
        }
        else
        {
            image.sprite = blackSprite;
        }

    }
    public void LoadLevelFastCall()
    {
        StartCoroutine(LoadLevelFast(destination));
    }


    IEnumerator LoadLevelFast(int levelIndex)
    {
        if (ProgressManager.Instance.furthestPoint >= destination || destination == 6) 
        {
            transition.SetTrigger("Start");

            StartGameEvent();

            yield return new WaitForSeconds(.5f);

            SceneManager.LoadScene(levelIndex);
        }
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
       Application.Quit();
       ProgressManager.Instance.SavePoint(); 
#endif
    }
}
