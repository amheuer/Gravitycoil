using System.Runtime.InteropServices;
using UnityEngine;
public class SiteLock : MonoBehaviour
{
    public static SiteLock Instance;
    public bool hasChecked;
    public string[] domains = new string[] {
       "https://www.coolmathgames.com",
       "www.coolmathgames.com",
       "https://edit.coolmathgames.com",
       "edit.coolmathgames.com",
       "www.stage.coolmathgames.com",
       "stage-edit.coolmathgames.com",
       "https://dev.coolmathgames.com",
       "https://www.stage.coolmathgames.com",
       "https://stage-edit.coolmathgames.com",
       "https://dev.coolmathgames.com",
       "https://dev-edit.coolmathgames.com"
   };
    [DllImport("__Internal")]


    private static extern void RedirectTo(string url);
    // Check right away if the domain is valid

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if(hasChecked != true)
        {
            CheckDomains();
            hasChecked = true;
        }
    }
    private void CheckDomains()
    {
        if (!IsValidHost(domains))
        {
            RedirectTo("www.coolmathgames.com");
        }
    }
    private bool IsValidHost(string[] hosts)
    {
        foreach (string host in hosts)
            if (Application.absoluteURL.IndexOf(host) == 0)
                return true;
        return false;
    }
}