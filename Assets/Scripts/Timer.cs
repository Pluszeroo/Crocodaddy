using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 240f; 
    private float currentTime;
    public ScoreManager score_mg;
    public int cScore;

    public TMP_Text timerText; 


    void Start()
    {
        cScore = 0;
        currentTime = totalTime;
        //totalScore = GetComponent<ScoreManager>();
        Debug.Log(score_mg.ToString());
        Debug.Log(score_mg.currentScore.ToString());
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            OnTimeUp();
        }

        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60f);
            int seconds = Mathf.FloorToInt(currentTime % 60f);
            timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }

    void OnTimeUp()
    {
        Debug.Log("Time Up");
        //Debug.Log(totalScore.currentScore);
        //SceneManager.LoadScene("Ending");

        cScore = score_mg.currentScore;

        if (cScore > 30)
        {
            SceneManager.LoadScene("GoodEnding");
            Debug.Log(1);
        }

        if (cScore > 22)
        {
            SceneManager.LoadScene("NormalEnding");
            Debug.Log(2);
        }

        if (cScore <= 22)
        {
            SceneManager.LoadScene("BadEnding");
            Debug.Log(3);
        }
    }
}