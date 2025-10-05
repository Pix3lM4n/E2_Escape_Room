using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("TestingScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void WinScene()
    {
        SceneManager.LoadScene("Win Scene");
    }
    public void LoseScene()
    {
        SceneManager.LoadScene("Lose Scene");
    }
}
