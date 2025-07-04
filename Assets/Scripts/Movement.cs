using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private SensorReader sensorReader;

    public float moveSpeed = 5f;
    public float inputAddSpeed = 1f;

    private float directionalSpeed, horizontalInput;

    private Vector3 lastPosition;
    public bool isMovingRight = true;
    public bool canWalk = true;
    public bool isGoingRight = true;
    [SerializeField]
    private Animator animator;

    private PlayerFallHandler fallHandler;

    [SerializeField]
    private GameObject sprite;
    private SpriteRenderer spriteRend;

    [HideInInspector] public Vector3 currentVelocity;

    AudioManager audioManager;

    //private Rigidbody2D rb;

    void Start()
    {
        lastPosition = transform.position;
        spriteRend = sprite.GetComponent<SpriteRenderer>();
        fallHandler = GetComponent<PlayerFallHandler>();
        //rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        Move();
        currentVelocity = (transform.position - lastPosition).normalized;
        lastPosition = transform.position;
        DetectMovementDirection();


        // reads the input of A/D or Left/Right. Is equal to 0 if not input pressed
        /* ternary operator => short version of:
         * if (isGoingRight == true)
         * {
         *      directionalSpeed = 1;
         * }
         * else
         * {
         *      directionalSpeed = -1;
         * }
         */
    }
    private void Move()
    {
        //Debug.Log("Starting to Move");
        horizontalInput = Input.GetAxis("Horizontal");
        //float horizontalInput = sensorReader.GetHorizontalInput();

        float boostSpeed = 0;

        if (horizontalInput > 0)
        {
            // if pressing right input, go faster
            isGoingRight = true;
            boostSpeed = inputAddSpeed;
        }

        if (horizontalInput < 0)
        {
            // if pressing left input, go opposite direction
            isGoingRight = false;
            boostSpeed = inputAddSpeed;
        }

        directionalSpeed = isGoingRight ? 1 : -1;

        //audioManager.PlaySFX(audioManager.footStep);
        float translationSpeed = (moveSpeed + boostSpeed) * directionalSpeed;


        // translate is the actual movement of the object
        //transform.Translate(new Vector2(translationSpeed * Time.deltaTime, 0));
        if (canWalk)
        {
            animator.SetBool("Attack", false);
            //move
            //Debug.Log("Moving");
            transform.Translate(new Vector2(translationSpeed * Time.deltaTime, 0));


        }
        else if (!canWalk)
        {
            if (!fallHandler.isFalling)
            {
                animator.SetBool("Attack", true);
            }
        }
    }

    private void DetectMovementDirection()
    {
        Vector3 currentPosition = transform.position;
        float deltaX = currentPosition.x - lastPosition.x;

        if (Mathf.Abs(deltaX) > 0.001f)  // small threshold to avoid noise
        {
            isMovingRight = deltaX > 0;
            //Debug.Log(isMovingRight ? "Actually moving right" : "Actually moving left");
        }

        lastPosition = currentPosition;

        if (currentVelocity.x > 0.01f)
        {
            sprite.transform.eulerAngles = new Vector3(0, 0, 0);
            isGoingRight = true;
        }
        else if (currentVelocity.x < -0.01f)
        {
            sprite.transform.eulerAngles = new Vector3(0, 180, 0);
            isGoingRight = false;
        }
    }

    //void LookAtTarget()
    //{


    //if (canWalk == false)
    //{
    //    LookAtTarget();
    //}
    //}

}