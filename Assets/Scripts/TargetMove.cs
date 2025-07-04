using UnityEngine;

public class TargetMove : MonoBehaviour
{

    public float speed = 2f;
    public float range = 3f;
    public bool moving = true;
    [SerializeField]
    private Transform player;
    private float startX;
    private bool movingRight = true;
    private TargetClick targetClick;

    [SerializeField]
    private Movement movement;

    [SerializeField]
    private GameObject sprite;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetClick = GetComponent<TargetClick>();
        spriteRenderer = sprite.GetComponent<SpriteRenderer>();
        //start position
        startX = transform.position.x;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving == false)
        {
            return;
        }

        if (!targetClick.captured)
        {
            float currentX = transform.position.x;

            //is this reach to the right
            if (movingRight && currentX >= startX + range)
            {
                movingRight = false;
            }
            //is this reach to the left
            else if (!movingRight && currentX <= startX - range)
            {
                movingRight = true;
            }

            //calculate the speed direction
            float direction = movingRight ? 1 : -1;

            transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

            if (movingRight)
            {
                spriteRenderer.flipX = true;
            }
            else if (!movingRight)
            {
                spriteRenderer.flipX = false;
            }
        }

        else
        {
            if (movement.isGoingRight)
            {
                spriteRenderer.flipX = true;
            }
            else if (!movement.isGoingRight)
            {
                spriteRenderer.flipX = false;
            }
        }
    }
}
