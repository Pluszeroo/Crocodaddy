using UnityEngine;

public class Competitor : MonoBehaviour
{
    public bool canCompete = false;
    [SerializeField]
    private TargetClick TargetClick;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Suga"))
        {
            TargetClick = collision.gameObject.GetComponent<TargetClick>();
            canCompete = true;
            TargetClick.competitor = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Suga"))
        {
            TargetClick.competitor = null;
            TargetClick = null;
            canCompete = false;
        }
    }
}
