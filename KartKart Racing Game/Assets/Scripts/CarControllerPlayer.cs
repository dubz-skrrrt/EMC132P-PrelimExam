using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerPlayer : MonoBehaviour
{

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private float CurrentSteerAngle;
    private float horizontalInput, verticalInput;
    private bool isBreaking;
    private float CurrentBreakForce;

    [SerializeField] private float motorForce;
    [SerializeField] private float BreakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider ColliderWheelFrontLeft;
    [SerializeField] private WheelCollider ColliderWheelFrontRight;
    [SerializeField] private WheelCollider ColliderWheelBackLeft;
    [SerializeField] private WheelCollider ColliderWheelBackRight;

    [SerializeField] private Transform transformWheelFrontLeft;
    [SerializeField] private Transform transformWheelFrontRight;
    [SerializeField] private Transform transformWheelBackLeft;
    [SerializeField] private Transform transformWheelBackRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        Steering();
        WheelMovement();

    }

    private void HandleMotor()
    {
        ColliderWheelFrontLeft.motorTorque = verticalInput * motorForce;
        ColliderWheelFrontRight.motorTorque = verticalInput * motorForce;
        CurrentBreakForce = isBreaking ? BreakForce : 0f;
        if (isBreaking)
        {
            ApplyBrake();
        }
    }

    private void ApplyBrake()
    {
        ColliderWheelBackLeft.brakeTorque = CurrentBreakForce;
        ColliderWheelBackRight.brakeTorque = CurrentBreakForce;
        ColliderWheelFrontLeft.brakeTorque = CurrentBreakForce;
        ColliderWheelFrontRight.brakeTorque = CurrentBreakForce;
    }

    private void Steering()
    {
        CurrentSteerAngle = maxSteerAngle * horizontalInput;
        ColliderWheelFrontLeft.steerAngle = CurrentSteerAngle;
        ColliderWheelFrontRight.steerAngle = CurrentSteerAngle;

    }

    private void WheelMovement()
    {
        UpdateSingleWheel(ColliderWheelFrontLeft, transformWheelFrontLeft);
        UpdateSingleWheel(ColliderWheelFrontRight, transformWheelFrontRight);
        UpdateSingleWheel(ColliderWheelBackLeft, transformWheelBackLeft);
        UpdateSingleWheel(ColliderWheelBackRight, transformWheelBackRight);

    }

    private void UpdateSingleWheel(WheelCollider wheelCollide, Transform wheelTransform)
    {
        Vector3 pos = wheelTransform.position;
        Quaternion rot = wheelTransform.rotation;
        wheelCollide.GetWorldPose(out pos, out rot);
        //wheelTransform.rotation = rot;
        // wheelTransform.position = pos;
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }
}
