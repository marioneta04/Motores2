using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score;
    public static GameManager inst;

    [SerializeField] Text scoreText;

    [SerializeField] PlayerMovement playerMovement;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;
       
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {

    }

    private void Update()
    {

    }
}
