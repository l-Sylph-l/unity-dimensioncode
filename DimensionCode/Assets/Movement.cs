using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Parameters
    public float runSpeed = 10f;
    
    public float turnSpeed = 0.1f;
    public float jumpHeight = 10f;
    public float jumpControll = 1f;
    
    //objects
    public Transform cameraTransform;
    //Grounded

    //Movement
    Vector2 input;
    Vector3 velocity;
    float currentSpeed;
    float currentVelocity;
    float turnSmoothVelocity;

    //Components
    Rigidbody rb;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Read Input
        ReadInput();
    }

    private void FixedUpdate()
    {
        //Rotate and Move Player
        Move();
        if (Input.GetButton("Jump"))
            {
            Jump();
        }

    }

    void ReadInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        input = new Vector2(horizontal, vertical);
        input = Vector2.ClampMagnitude(input, 1);
    }

    void Move()
    {
        if (input != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.localEulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSpeed);
        }

        //Calculate TargetSpeed
        float targetSpeed = runSpeed * input.magnitude; //input.magnitude is between 0 and 1 -> targetSpeed between 0 and runSpeed

        ////currentSpeed = new Vector2(rb.velocity.x, rb.velocity.z).magnitude;
        //currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref currentVelocity, speedSmoothTime); //Gradually changes a value towards a desired goal over time.
        //velocity = transform.forward * currentSpeed * Time.deltaTime;

        velocity = transform.forward * targetSpeed /** Time.deltaTime*/;

        rb.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    void Jump()
    {
        rb.velocity = Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);    
        
    }
}
