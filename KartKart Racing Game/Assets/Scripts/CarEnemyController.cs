using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CarEnemyController : MonoBehaviour
{

    public Transform Path;
    private List<Transform> waypoint;
    
    private int currentPoint = 0;
    private float newSteer;
    public float maxSteerAngle = 45f;

    public WheelCollider wheelFL, WheelFR;
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
        ApplySteer();
        AIMove();
        CheckWayPointDistance();
    }

    private void ApplySteer()
    {   
        Vector3 relativeVector = transform.InverseTransformPoint(waypoint[currentPoint].position);
        newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        wheelFL.steerAngle = newSteer;
        WheelFR.steerAngle = newSteer;
    }

    private void AIMove()
    {
        wheelFL.motorTorque = 100f;
        WheelFR.motorTorque = 100f;
    }

    private void CheckWayPointDistance()
    {
        
        if (Vector3.Distance(transform.position, waypoint[currentPoint].position) < 2f)
        {
           
            if (currentPoint == waypoint.Count - 1){
                currentPoint = 0;

            }else{
                currentPoint += 1;
                
            }
        }
    }
}
