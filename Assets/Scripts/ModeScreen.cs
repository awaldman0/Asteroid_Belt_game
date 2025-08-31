using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeScreen : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void Normal()
    {
        if (ModeManager.Instance != null)
        {
            ModeManager.Instance.SelectNormalMode();
        }
    }

    public void Hard()
    {
        if (ModeManager.Instance != null)
        {
            ModeManager.Instance.SelectHardMode();
        }
    }

    public void Infinite()
    {
        if (ModeManager.Instance != null)
        {
            ModeManager.Instance.SelectInfiniteMode();
        }
    }
}
