using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public static bool isOnPause = false;

    [SerializeField] private GameObject pauseMenu;

    public void OnPauseClicked()
    {
        if (isOnPause)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isOnPause = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isOnPause = true;
    }
}
