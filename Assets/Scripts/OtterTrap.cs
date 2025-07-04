using UnityEngine;
using System.Collections;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class OtterTrap : MonoBehaviour
{
    //public delegate void OnPlayerCollidedHandler();
    //public static event OnPlayerCollidedHandler OnPlayerCollided;

    private PlayerFallHandler mFallHandler;
    private bool hasTriggered = false;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        mFallHandler = FindAnyObjectByType<PlayerFallHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasTriggered) return;

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player has entered one of the triggers");
            hasTriggered = true;
            mFallHandler.isFalling = true;
            audioManager.PlaySFX(audioManager.otterHit);
            StartCoroutine(PlayBabyCryDelayed(0.5f));

            IEnumerator PlayBabyCryDelayed(float delay)
            {
                yield return new WaitForSeconds(delay);
                audioManager.PlaySFX(audioManager.babyCry);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        hasTriggered = false;
    }
}
