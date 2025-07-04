using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int currentScore;
    public TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject superMommy;
    [SerializeField]
    private GameObject superDaddy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        superMommy.SetActive(false);
        superDaddy.SetActive(false);
        currentScore = 0;
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
    private void Update()
    {
        //Debug.Log(currentScore);
        if(currentScore == 18f)
        {
            superMommy.SetActive(true);
        }

        if(currentScore == 28f)
        {
            superDaddy.SetActive(true);
        }
    }
}
