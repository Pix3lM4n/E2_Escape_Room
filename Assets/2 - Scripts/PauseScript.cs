using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    private GameObject settingsUI;
    

    private void Awake()
    {
        settingsUI = GameObject.Find("SettingsUI");
    }

    private void Start()
    {
        settingsUI.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsUI.SetActive(true);
    }
    public void HideSettings()
    {
        settingsUI.SetActive(false);
    }
}
