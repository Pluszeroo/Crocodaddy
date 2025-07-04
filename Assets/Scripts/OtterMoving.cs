using UnityEngine;

public class OtterMoving : MonoBehaviour
{
    public float speed = 2f;
    public float range = 16f;
    public bool moving = true;
    private float startX;
    private bool movingRight = true;

    [SerializeField]
    private SpriteRenderer otterSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        otterSprite.GetComponent<Renderer>();
        startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        float currentX = transform.position.x;

        if (!moving)
        {
            return;
        }

        if (movingRight && currentX >= startX + range)
        {
            movingRight = false;
        }

        else if (!movingRight && currentX <= startX - range)
        {
            movingRight = true;
        }

        float direction = movingRight ? 1 : -1;

        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        if (movingRight)
        {
            otterSprite.flipX = true;
        }
        else if (!movingRight)
        {
            otterSprite.flipX = false;
        }

    }
}
