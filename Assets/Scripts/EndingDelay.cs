using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingDelay : MonoBehaviour
{
    public float delay = 8.6f;

    void Start()
    {
        Invoke("LoadCredits", delay);
    }

    void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}