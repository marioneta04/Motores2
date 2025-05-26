using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerSS : MonoBehaviour
{
    public float score = 0f;
    public float pointsPerSecond = 10f;
    public Text scoreText;

    void Update()
    {
        score += pointsPerSecond * Time.deltaTime;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }
    }
}
