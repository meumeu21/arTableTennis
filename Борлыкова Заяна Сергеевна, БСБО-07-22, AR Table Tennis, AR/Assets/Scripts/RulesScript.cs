using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RulesScript : MonoBehaviour
{
    public int score = 0;
    [SerializeField] private GameObject rulesUI;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private GameObject ball;
    private BallMovementScript bm;

    private void Awake()
    {
        bm = ball.GetComponent<BallMovementScript>();
    }

    public void OnButtonClicked()
    {
        switch (buttonText.text)
        {
            case "21":
                score = 21;
                break;
            case "11":
                score = 11;
                break;
            case "6":
                score = 6;
                break;
        }
        ScoreScript.totalScore = score;
        rulesUI.SetActive(false);
        bm.StartingPosition(true);
    }
}
