using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public float UpForce = 0.0f; // Total foce applied to motor. Will be transfered to main RB
    public float SideForce = 0.0f; // Torque or sideforce appiled by this motor.  This may be transfered to the parent RigidBody and get computed with others motors
    public float Power = 2; // A power multiplier. An easy way to create more potent motors
    public float ExceedForce = 0.0f; // Negative force value when UpForce gets below 0

    public float YawFactor = 0.0f;  // A factor to be applied to the side force.  Higher values get a faster Yaw movement
    public float PitchFactor = 0.0f; // A factor to be applied to the pitch correction
    public float RollFactor = 0.0f; // A factor to be applied to the roll correction
    public bool InvertDirection; // Whether the direction of the motor is counter or counterclockwise

    public float Mass = 0.0f;

    public BasicControl mainController; // Parent main controller.  Where usually may be found the RigidBody
    public GameObject Propeller; // The propeller object.  Annimation will be done here.
    private float SpeedPropeller = 0;


    public void UpdateForceValues()
    {
        float UpForceThrottle = Mathf.Clamp(mainController.ThrottleValue, 0, 1) * Power;
        float UpForceTotal = UpForceThrottle;
        UpForceTotal -= mainController.Computer.PitchCorrection * PitchFactor;
        UpForceTotal -= mainController.Computer.RollCorrection * RollFactor;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
