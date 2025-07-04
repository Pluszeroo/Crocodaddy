using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private int currentScore = 0;
    public TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //currentScore = 0;
    }

    // Update is called once per frame
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        scoreText.text = "Score: " + currentScore;
    }
}
