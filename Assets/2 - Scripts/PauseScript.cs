using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    private GameObject pauseScreen;
    private GameObject menuUI;
    private GameObject settingsUI;
    public AudioSource SFXSource;
    public AudioResource clickClip;
    
    private void Awake()
    {
        pauseScreen = GameObject.Find("Pause Screen");
        menuUI = GameObject.Find("MenuUI");
        settingsUI = GameObject.Find("SettingsUI");
    }

    private void Start()
    {
        pauseScreen.SetActive(false);
        menuUI.SetActive(false);
        settingsUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OpenMenu();
        }
    }

    public void OpenMenu()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        menuUI.SetActive(true);
    }

    public void HideMenu()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        menuUI.SetActive(false);
    }
    public void OpenSettings()
    {
        menuUI.SetActive(false);
        settingsUI.SetActive(true);
    }
    public void HideSettings()
    {
        menuUI.SetActive(true);
        settingsUI.SetActive(false);
    }
}
