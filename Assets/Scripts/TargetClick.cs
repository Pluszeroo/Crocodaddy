using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TargetClick : MonoBehaviour

{
    [SerializeField]
    private float minusAMT = 0.2f;
    private bool addScore;
    public bool beingClicked = false;
    public float fillSpeed = 1f;
    public Image drinkLiquidImage;
    public float playerClosenessNeeded = 6f;
    public bool captured;
    public Competitor competitor;

    public GameObject glassPrefab;
    public Transform glassDropPoint;

    private bool glassDroped = false;

    private Transform player;
    private float playerDistance;
    private TargetMove movement;
    private FollowPlayer followScript;
    private Movement playerMovement;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator;

    AudioManager audioManager;

    //private Target currenTarget;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        followScript = GetComponent<FollowPlayer>();
        followScript.enabled = false;
        playerMovement = FindAnyObjectByType<Movement>();
        //Find the object with the player tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
        movement = GetComponent<TargetMove>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        playerDistance = Vector3.Distance(transform.position, player.position);
        if (competitor == null)
        {
            ClickFuntion();
        }
        else
        {
            Compete();
        }
    }

    private void Compete()
    {

        if (beingClicked && playerDistance > playerClosenessNeeded)
        {
            movement.moving = true;
            animator.SetBool("Attacked", false);
            animator.SetBool("Captured", false);
        }

        else if (beingClicked && playerDistance < playerClosenessNeeded)
        {
            drinkLiquidImage.fillAmount = 0.3f;
            movement.moving = false;
            //Fill the drink
            audioManager.PlaySFX(audioManager.shaking);
            audioManager.PlaySFX(audioManager.chime);
            spriteRenderer.flipX = !playerMovement.isGoingRight;

            audioManager.PlaySFX(audioManager.liquidPour);
            drinkLiquidImage.fillAmount -= minusAMT;

            if (drinkLiquidImage.fillAmount >= 1f && !glassDroped)
            {
                Debug.Log("competed over ");
                captured = true;
                DropGlass();

                // Queue follow logic begins here
                movement.moving = false;
                GetComponent<TargetMove>().enabled = false;

                FollowerQueue.Register(transform);
                followScript.enabled = true;
                //spriteRenderer.flipX = playerMovement.isGoingRight;

                animator.SetBool("Captured", true);
                drinkLiquidImage.gameObject.SetActive(false);
            }
        }
        else
        {
            movement.moving = true;
        }
    }

    private void ClickFuntion()
    {
        //How close is the player

        if (beingClicked && playerDistance > playerClosenessNeeded)
        {
            movement.moving = true;
            animator.SetBool("Attacked", false);
            animator.SetBool("Captured", false);
        }

        else if (beingClicked && playerDistance < playerClosenessNeeded)
        {
            movement.moving = false;
            //Fill the drink
            audioManager.PlaySFX(audioManager.chime);
            spriteRenderer.flipX = !playerMovement.isGoingRight;

            audioManager.PlaySFX(audioManager.shaking);
            StartCoroutine(PlayliquidPourDelayed(0.5f));

            IEnumerator PlayliquidPourDelayed(float delay)
            {
                yield return new WaitForSeconds(delay);
                audioManager.PlaySFX(audioManager.babyCry);
            }

            drinkLiquidImage.fillAmount += Time.deltaTime * fillSpeed;

            if (drinkLiquidImage.fillAmount >= 1f && !glassDroped)
            {
                captured = true;
                DropGlass();

                // Queue follow logic begins here
                movement.moving = false;
                GetComponent<TargetMove>().enabled = false;

                FollowerQueue.Register(transform);
                followScript.enabled = true;
                //spriteRenderer.flipX = playerMovement.isGoingRight;

                animator.SetBool("Captured", true);
                drinkLiquidImage.gameObject.SetActive(false);
            }
        }
        else
        {
            movement.moving = true;
        }
    }

    private void DropGlass()
    {
        Instantiate(glassPrefab, glassDropPoint.position, Quaternion.identity);
        glassDroped = true;
        audioManager.PlaySFX(audioManager.glassDrop);

        drinkLiquidImage.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (competitor == null)
        {
            if (playerDistance < playerClosenessNeeded)
            {
                beingClicked = true;
                playerMovement.canWalk = false;
                animator.SetBool("Attacked", true);
            }
        }
        else
        {
            drinkLiquidImage.fillAmount += 0.3f;
        }
    }

    private void OnMouseUp()
    {
        beingClicked = false;
        playerMovement.canWalk = true;
        animator.SetBool("Attacked", false);
    }
}
