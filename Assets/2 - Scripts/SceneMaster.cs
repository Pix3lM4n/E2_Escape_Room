using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Test Scene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
