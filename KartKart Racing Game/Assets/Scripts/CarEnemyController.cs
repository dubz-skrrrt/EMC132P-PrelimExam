using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CarEnemyController : MonoBehaviour
{

    public Transform Path;
    private List<Transform> waypoint;
    public Transform leftFrontWheel, rightFrontWheel;
    private int currentPoint = 0;
    private float newSteer;
    public float maxSteerAngle = 45f;

    public float maxSpeed = 100f, maxMotorTorque = 80f,  currentSpeed, decelaration = 10f;
    public WheelCollider wheelFL, WheelFR;

    private static float timer;
    // Start is called before the first frame update
    void Start()
    {
        Transform[] pathTransform = Path.GetComponentsInChildren<Transform>();

        waypoint = new List<Transform>();
        // gets the index for each child in the system
        for(int i = 0; i < pathTransform.Length; i++)
        {
            if (pathTransform[i] != Path.transform)
            {
                waypoint.Add(pathTransform[i]);
            }
        }
    }

    // Update is called once per frame
   
    private void FixedUpdate()
    {
        timer = CountDownTimer.currentTime;
        ApplySteer();
        AIMove();
        CheckWayPointDistance();
        
        
    }

    private void ApplySteer()
    {   
        // changes and adjusts the rotation of the wheel colliders based on the current waypoint 
        Vector3 relativeVector = transform.InverseTransformPoint(waypoint[currentPoint].position);
        newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        wheelFL.steerAngle = newSteer;
        WheelFR.steerAngle = newSteer;

        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, wheelFL.steerAngle, leftFrontWheel.localRotation.eulerAngles.z);
        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, WheelFR.steerAngle, rightFrontWheel.localRotation.eulerAngles.z);
    }

    private void AIMove()
    {
        if (timer == 0)
        {
        //adds movement to the ai
            currentSpeed = 2 * Mathf.PI * wheelFL.radius * WheelFR.rpm * 60 / 1000;

            if (currentSpeed < maxSpeed)
            {
                wheelFL.motorTorque = maxMotorTorque;
                WheelFR.motorTorque = maxMotorTorque;
                wheelFL.brakeTorque = 0;
                WheelFR.brakeTorque = 0;
            }else
            {
                wheelFL.brakeTorque = decelaration;
                WheelFR.brakeTorque = decelaration;
                wheelFL.motorTorque = 0;
                WheelFR.motorTorque = 0;
            }
        }
       
    }

    private void CheckWayPointDistance()
    {
        //Checks the distance between the position of the ai and the current waypoint in the list
        if (Vector3.Distance(transform.position, waypoint[currentPoint].position) < 2f)
        {
           //checks if the current waypoint is zero; 
            if (currentPoint == waypoint.Count - 1){
                currentPoint = 0;

            }else
            {
                //else changes the current waypoint to the next one
                currentPoint += 1;
                
            }
        }
    }
}
