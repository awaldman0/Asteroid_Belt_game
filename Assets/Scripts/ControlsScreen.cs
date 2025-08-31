using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsScreen : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
