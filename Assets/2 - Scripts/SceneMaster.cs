using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Pablo");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
