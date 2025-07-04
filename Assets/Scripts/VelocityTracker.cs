using UnityEngine;
using UnityEngine.UIElements;

public class VelocityTracker : MonoBehaviour
{
    public Vector3 lastPosition;
    public Vector3 currentVelocity
    {
        //Get the volicity value from the outside the class
        get; private set;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Did I miss anything in here?
    }

    // Update is called once per frame
    void LateUpdate()
    {
        currentVelocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
    }
}
