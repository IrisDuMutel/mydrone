using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Module reuniting computing parts of a drone.  Used by a BasicControl.

public class ComputerModule : MonoBehaviour
{
    [Header("Settings")]
    [Range(0, 90)] public float PitchLimit; //Variable limited within range
    [Range(0, 90)] public float RollLimit; //Variable limited within range

    [Header("Parts")]
    public PID PidThrottle;
    public PID PidRoll;
    public PID PidPitch;
    public BasicGyro Gyro;

    [Header("Values")]
    public float PitchCorrection;
    public float RollCorrection;
    public float HeightCorrection;

    public void UpdateComputer(float ControlPitch, float ControlRoll, float ControlHeight)
    {
        UpdateGyro();
        PitchCorrection = PidPitch.Update(ControlPitch * PitchLimit, Gyro.Pitch, Time.deltaTime);
        RollCorrection = PidRoll.Update(ControlRoll * RollLimit, Gyro.Roll, Time.deltaTime);
        HeightCorrection = PidThrottle.Update(ControlHeight, Gyro.VelocityVector.y, Time.deltaTime);

    }

    public void Reset()
    {
        PitchCorrection = 0.0f;
        RollCorrection = 0.0f;
        HeightCorrection = 0.0f;

        Gyro.Reset();
        PidPitch.Reset();
        PidRoll.Reset();
        PidThrottle.Reset();
    }
    public void UpdateGyro()
    {
        Gyro.UpdateGyro(transform);
    }
}
