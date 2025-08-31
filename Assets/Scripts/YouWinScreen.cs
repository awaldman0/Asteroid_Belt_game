using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinScreen : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadSceneAsync("Game");
    }
    public void Menu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
