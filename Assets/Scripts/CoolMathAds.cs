using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


public class CoolMathAds : MonoBehaviour
{

    public bool isMuted;
    public static CoolMathAds instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null && instance != this)
        {
            Destroy(this);
        }
    }


    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PauseGame()
    {
        Debug.Log("PauseGame function called");
        Time.timeScale = 0f;
        isMuted = true;
        //ADD LOGIC TO MUTE SOUND HERE
    }


    public void ResumeGame()
    {
        isMuted = false;
        Debug.Log("ResumeGame function called");
        Time.timeScale = 1.0f;
        //ADD LOGIC TO UNMUTE SOUND HERE
    }

    public void InitiateAds()
    {
        triggerAdBreak();
    }
    [DllImport("__Internal")]
    private static extern void triggerAdBreak();
}

