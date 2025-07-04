using System.Collections;
using UnityEngine;

public class PlayerFallHandler : MonoBehaviour
{

    private Movement movementScripts;
    //private bool isFalling = false;
    [SerializeField]
    private Animator animator;
    public bool isFalling = false;

    public OtterTrap trap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementScripts = GetComponent<Movement>();
    }

    private void Update()
    {
        if (isFalling)
        {
            FallOver();
        }
    }

    // Update is called once per frame

    void FallOver()
    {
        StartCoroutine(FallRoutine());
        // set animator to fall over
    }

    IEnumerator FallRoutine()
    {
        Debug.Log("Falling over");
        animator.SetBool("Falling", true);
        movementScripts.canWalk = false;
        yield return new WaitForSeconds(5f);
        isFalling = false;
        animator.SetBool("Falling", false);
        movementScripts.canWalk = true;
    }

}
