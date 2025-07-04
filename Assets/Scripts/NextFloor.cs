using UnityEngine;

public class NextFloor : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Vector3 currentPosition;
    [SerializeField]
    private float xValue;
    [SerializeField]
    private float yValue;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    void Update()
    {
        currentPosition = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Player climbing Stairs");
            audioManager.PlaySFX(audioManager.transition);
            player.gameObject.transform.position = currentPosition + new Vector3(xValue, yValue, 0f);
        }
    }
}
