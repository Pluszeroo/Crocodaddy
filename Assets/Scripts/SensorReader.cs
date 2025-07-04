using UnityEngine;

//using Gyroscope = UnityEngine.InputSystem.Gyroscope;

public class SensorReader : MonoBehaviour
{
    //public float xdirection;
    //public float moveSpeed = 5f;
    //public Rigidbody2D rb;
    //public float tiltmoveSpeed = 5f;
    //float acceleration = 0.5f;
    public float moveSpeed = 12f;

    private Movement movement;
    //private Vector3 defaultDirection = Vector3.right;
    ////public float forceAmount = 10f;
    ////public Vector3 movementDirection = Vector3.forward;

    void Start()
    {
        movement = FindAnyObjectByType<Movement>();
        //rb = GetComponent<Rigidbody2D>();
        ////InputSystem.EnableDevice(Gyroscope.current);
        //InputSystem.EnableDevice(Accelerometer.current);
        ////InputSystem.EnableDevice(AttitudeSensor.current);
        ////InputSystem.EnableDevice(GravitySensor.current);
    }

    //// Update is called once per frame
    void Update()
    {
        if (movement.canWalk)
        {
            float tilt = Input.acceleration.x;
            tilt = Mathf.Clamp(tilt, -1, 1);
            Vector2 move = new Vector2(tilt * moveSpeed * Time.deltaTime, 0);
            transform.Translate(move);
        }
        else
        {
            return;
        }
        //    //Get the acceleration value from the accelerometer
        //    transform.Translate(defaultDirection * moveSpeed * Time.deltaTime);
        //    Vector3 acceleration = Accelerometer.current.acceleration.ReadValue();
        //    xdirection = acceleration.x * tiltmoveSpeed;
    }

    //private void FixedUpdate()
    //{
    //    //rb.AddForce(movementDirection * forceAmount, ForceMode2D.linearVelocity);
    //    rb.linearVelocityX = xdirection;
    //}

    // TODO: needs to be a value between -1 and 1
    // need to figure out how to read Input.acceleration,
    // what values does it give in various orientations of the device,
    // and how to convert it to the -1 to 1 range
    public float GetHorizontalInput()
    {
        //Debug.Log(Input.acceleration);
        return Mathf.Clamp(Input.acceleration.x, -1f, 1f);
    }
}
