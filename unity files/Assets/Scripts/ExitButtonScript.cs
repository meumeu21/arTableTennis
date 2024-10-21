using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExitButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject scoreUI;
    private TextMeshProUGUI scoreText;

    [SerializeField] private GameObject startButton;
    private Button stB;
    [SerializeField] private GameObject quitButton;
    private Button qtB;
    [SerializeField] private GameObject optionsButton;
    private Button opB;

    [SerializeField] private GameObject confettigif;

    public bool isPauseMenu;
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private GameObject ball;
    private BallMovementScript bm;

    [SerializeField] private GameObject pauseMenuButton;
    private PauseMenuScript pm;

    public void OnPressedButton()
    {
        scoreText = scoreUI.GetComponent<TextMeshProUGUI>();
        scoreText.text = "Player score: 0 \nOpponent score: 0";
        menuUI.SetActive(true);
        stB = startButton.GetComponent<Button>();
        qtB = quitButton.GetComponent<Button>();
        opB = optionsButton.GetComponent<Button>();
        stB.interactable = true;
        qtB.interactable = true;
        opB.interactable = true;
        if (!isPauseMenu)
        {
            exitButton.SetActive(false);
        }
        else
        {
            bm = ball.GetComponent<BallMovementScript>();
            bm.EndedGame();
        }
        pauseMenuButton.SetActive(true);
        pm = pauseMenuButton.GetComponent<PauseMenuScript>();
        pm.Resume();
        ScoreScript.flag = 0;
        ScoreScript.currentOpponentScore = ScoreScript.currentPlayerScore = 0;
        confettigif.SetActive(true);
    }
}
