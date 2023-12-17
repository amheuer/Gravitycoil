using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public static float savevolume;
    public static int savequalityIndex;

    private void Start()
    {
        savevolume = 0;
        savequalityIndex = 2;

        SetVolume(savevolume);
        SetQuality(savequalityIndex);
    }

    public void SetVolume(float volume)
    {
        ProgressManager.Instance.savevolume = volume;
    }

    public void SetQuality(int qualityIndex)
    {
        ProgressManager.Instance.savequalityIndex = qualityIndex;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }


}
