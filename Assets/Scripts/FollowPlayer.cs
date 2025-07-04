using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 10f;
    public float stopDistance = 4;
    public float spacing = 2f;
    private Movement playerMovement;
    [SerializeField] 
    private float yOffset = 0.5f;
    private Vector3 lastPosition;
    //[SerializeField] 
    //private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastPosition = transform.position;
        //spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!enabled) return;

        // Get target to follow based on queue index
        Transform target = FollowerQueue.GetFollowTarget(transform);
        int index = FollowerQueue.GetIndex(transform);

        // Calculate offset behind the target (player or previous follower)
        Vector3 moveDir = playerMovement.currentVelocity;

        if (moveDir.magnitude < 0.01f)
            moveDir = playerMovement.isGoingRight ? Vector3.right : Vector3.left;

        Vector3 offset = -moveDir.normalized * spacing;
        Vector3 targetPos = target.position + offset;
        targetPos.y = playerMovement.transform.position.y + yOffset;

        // Move toward the calculated position
        transform.position = Vector3.MoveTowards(transform.position, targetPos, followSpeed * Time.deltaTime);

        // Flip to match the target's direction
        Vector3 delta = transform.position - lastPosition;
        lastPosition = transform.position;

        if (Mathf.Abs(delta.x) > 0.01f)
        {
            Vector3 scale = transform.localScale;

            // Art faces LEFT by default
            scale.x = delta.x < 0 ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);

            transform.localScale = scale;
        }

        // Original stopDistance logic no longer used in queue-based following
        // float distance = Vector3.Distance(transform.position, player.position);
        // if (distance > stopDistance)
        // {
        //     Vector3 direction = (player.position -  transform.position).normalized;
        //     transform.position += direction * followSpeed * Time.deltaTime;
        // }

        //Child();
    }

    //void Child()
    //{
    //    gameObject.transform.parent = player.transform;
    //}
}
