using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // reference for rigid body
    public Rigidbody theRB; 

    //variables needed for the movement of the car
    public float forwardAccel = 8f, reverseAccel = 4f, maxSpeed = 50f, turnStrength = 180, gravityForce = 10f, dragOnGround = 3f;

    private float speedInput, turnInput;

    // To know if car is on the ground
    private bool grounded;

    public LayerMask whatisGround;
    public float groundRayLength = .5f;
    public Transform groundRayPoint;

    // to access the tranform rotation of the wheels on the car
    public Transform leftFrontWheel, rightFrontWheel;
    
    
    public float maxWheelTurn = 20f;

    private static float timer;
    void Start()
    {
        // makes the sphere not part of the parent so as to make the car follow the sphere
        theRB.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        // gives the car forward and backward movement
        timer = CountDownTimer.timer;
        speedInput = 0f;
        
        if (timer == 0)
        {
            if (Input.GetAxis("Vertical")> 0)
            {
                speedInput  = Input.GetAxis("Vertical") * forwardAccel * 10000f * Time.deltaTime;
                

            }else if (Input.GetAxis("Vertical") < 0)
            {
                speedInput = Input.GetAxis("Vertical") * reverseAccel *7000f * Time.deltaTime;
            }

        
            // lets the car rotate at the x plane
            turnInput = Input.GetAxis("Horizontal");
            transform.position = theRB.transform.position;
            
            if (grounded)
            {
                // let's the player rotate only when moving forward or backward only on ground
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
                
            }
            // rotates the wheels to make it look natural

        
            leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, turnInput * maxWheelTurn, leftFrontWheel.localRotation.eulerAngles.z);
            rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, turnInput * maxWheelTurn, rightFrontWheel.localRotation.eulerAngles.z);
        }
    }

    private void FixedUpdate()
    {
        // determines whether or not the car is in the air or in the ground
        grounded = false;
        RaycastHit hit;
        
        if (Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, whatisGround))
        {
            grounded = true;
            
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
        
        if (grounded)
        {
            theRB.drag = dragOnGround;
            if(Mathf.Abs(speedInput)> 0)
            {
                theRB.AddForce(transform.forward * speedInput);
            }
        }else
        {
            // adds acceleration when going from the ground to the air
            theRB.drag = 0.1f;
            theRB.AddForce(Vector3.up * -gravityForce * 100f);
        }
    }
}
