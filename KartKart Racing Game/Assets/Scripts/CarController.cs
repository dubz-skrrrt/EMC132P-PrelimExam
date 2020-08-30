using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public WheelCollider wheelFLCol, wheelFRCol, wheelBLCol, wheelBRCol;

    public Transform wheelFLT, wheelFRT, wheelBLT, wheelBRT;

    public float _steerAngle = 25.0f;
    
    public float _motorForce = 1500f;
    public float maxSteerAngle;

    float inputX, inputY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        GetInputs();
        Drive();
        steerCar();

        // UpdateWheels(wheelFRCol, wheelFRT);
        // UpdateWheels(wheelFLCol, wheelFLT);
        // UpdateWheels(wheelBRCol, wheelBRT);
        // UpdateWheels(wheelBLCol, wheelBLT);
    }

    private void GetInputs()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

    }

    private void Drive()
    {
        wheelBLCol.motorTorque = inputY * _motorForce;
        wheelBRCol.motorTorque = inputY * _motorForce;
    }

    private void steerCar()
    {
        maxSteerAngle = _steerAngle * inputX;
        wheelFLCol.steerAngle = maxSteerAngle;
        wheelFRCol.steerAngle = maxSteerAngle;

    }

    private void UpdateWheels(WheelCollider col, Transform t)
    {
        Vector3 pos = t.position;
        Quaternion rot = t.localRotation;

        col.GetWorldPose(out pos, out rot);
        
        // t.position = pos;
        // t.localRotation = rot;
    }
}
