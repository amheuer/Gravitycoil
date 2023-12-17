using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;
    public int furthestPoint = 0;
    public AudioMixer audioMixer;
    public float savevolume;
    public int savequalityIndex;

    [DllImport("__Internal")]
    private static extern void StartGameEvent();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPoint();
    }

    public void Start()
    {
        StartGameEvent();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }


    private void Update()
    {
       if (furthestPoint < 4)
       {
            furthestPoint = 4;
       }

        if (furthestPoint < SceneManager.GetActiveScene().buildIndex)
        {
            furthestPoint = SceneManager.GetActiveScene().buildIndex;
            ProgressManager.Instance.SavePoint();
        }

        SetVolume(savevolume);
        SetQuality(savequalityIndex);

    }

    [System.Serializable]
    class SaveData
    {
        public int furthestPoint;
    }

    public void SavePoint()
    {
#if UNITY_EDITOR

#else
        SaveData data = new SaveData();
        data.furthestPoint = furthestPoint;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
#endif

    }

    public void LoadPoint()
    {
#if UNITY_EDITOR

#else
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            furthestPoint = data.furthestPoint;
        }
#endif

    }
}
