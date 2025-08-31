using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadSceneAsync("Game");
    }
    public void Controls()
    {
        SceneManager.LoadSceneAsync("ControlsScreen");
    }

    public void Mode()
    {
        SceneManager.LoadSceneAsync("ModeScreen");
    }


    public void Exit()
    {
        Application.Quit();
    }
}
