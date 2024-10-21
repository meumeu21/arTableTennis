using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject rulesUI;
    [SerializeField] private GameObject optionsUI;
    [Header("Menu Buttons")]
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button quitGameButton;

    public void OnStartGameClicked()
    {
        DisableMenuButtons();
        menuUI.SetActive(false);
        rulesUI.SetActive(true);
    }

    public void OnOptionsClicked()
    {
        DisableMenuButtons();
        menuUI.SetActive(false);
        optionsUI.SetActive(true);
    }

    public void OnQuitGameClicked()
    {
        DisableMenuButtons();
        Application.Quit();
    }

    private void DisableMenuButtons()
    {
        startGameButton.interactable = false;
        optionsButton.interactable = false;
        quitGameButton.interactable = false;
    }
}
