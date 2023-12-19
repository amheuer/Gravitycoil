using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;


public class Continue : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void StartGameEvent(); 

    public Animator transition;
    public int destination;
    void Update()
    {
        if (ProgressManager.Instance.furthestPoint <= 4)
        {
            destination = 4;
        }
        else
        {
            destination = ProgressManager.Instance.furthestPoint;
        }
    }

public void LoadLevelFastCall()
{
    StartCoroutine(LoadLevelFast(destination));
}


IEnumerator LoadLevelFast(int levelIndex)
{

    transition.SetTrigger("Start");

    StartGameEvent();

    yield return new WaitForSeconds(.5f);

    SceneManager.LoadScene(levelIndex);

}
}
