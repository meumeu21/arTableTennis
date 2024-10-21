using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static int totalScore;
    private TextMeshProUGUI scoreText;
    public static int currentPlayerScore;
    public static int currentOpponentScore;
    private static int ucps;
    private static int ucos;
    public static int flag = 0;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject confettigif;
    private Animator confettigifanim;
    public static bool playerWon = false;

    [SerializeField] private GameObject pauseMenuButton;

    private void Awake()
    {
        scoreText = this.GetComponent<TextMeshProUGUI>();
        confettigifanim = confettigif.GetComponent<Animator>();
    }

    private void Update()
    {
        if (currentOpponentScore != ucos || currentPlayerScore != ucps)
        {
            OnGameEnded();
            switch (flag)
            {
                case 0:
                    scoreText.text = "Player score: " + currentPlayerScore + "\nOpponent score: " + currentOpponentScore;
                    break;
                case 1:
                    scoreText.text = "OPPONENT WON...";
                    pauseMenuButton.SetActive(false);
                    break;
                case 2:
                    scoreText.text = "YOU WON!";
                    playerWon = true;
                    pauseMenuButton.SetActive(false);
                    break;
                case 3:
                    scoreText.text = " ";
                    break;
            }
            if (playerWon) { confettigifanim.Play("confettigifanim"); playerWon = false; }
        }
        ucps = currentPlayerScore;
        ucos = currentOpponentScore;
    }

    public bool OnGameEnded()
    {
        if (currentPlayerScore >= totalScore || currentOpponentScore >= totalScore)
        {
            if (currentOpponentScore - currentPlayerScore >= 2)
            {
                exitButton.SetActive(true);
                currentOpponentScore = currentPlayerScore = 0;
                flag = 1;
                return true;
            }
            else if (currentPlayerScore - currentOpponentScore >= 2)
            {
                exitButton.SetActive(true);
                currentOpponentScore = currentPlayerScore = 0;
                flag = 2;
                return true;
            }
            else { return false; }
        }
        else { return false; }
    }
}
