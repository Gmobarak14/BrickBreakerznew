using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    private GameManager gameManager;
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        scoreText = GetComponent<TextMeshProUGUI>();

        
        UpdateScoreText();
    }

    private void Update()
    {
      
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        // Check if the GameManager instance and scoreText are not null
        if (gameManager != null && scoreText != null)
        {
            // Update the score text with the current score from GameManager
            scoreText.text = "SCORE: " + gameManager.score.ToString();
        }
    }
}
