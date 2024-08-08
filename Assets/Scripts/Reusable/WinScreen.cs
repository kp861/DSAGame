using TMPro;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        finalScoreText.text = "Final Score: " + scoreKeeper.GetScore();
    }
}
