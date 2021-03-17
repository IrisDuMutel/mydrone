using UnityEngine;
using System.Collections;
// used by ComputerModule.cs
// Basic gyroscope simulator.  Uses the zero and identity to calculate.  This one suffers from gimball lock effect
[System.Serializable]
public class BasicGyro
{


	public float Pitch; // The current pitch for the given transform
	public float Roll; // The current roll for the given transform
	public float Yaw; // The current Yaw for the given transform
	public float Altitude; // The current altitude from the zero position
	public Vector3 VelocityVector; // Velocity vector
	public float VelocityScalar; // Velocity scalar value

	public void UpdateGyro(Transform transform)
	{
		Pitch = transform.eulerAngles.x;
		Pitch = (Pitch > 180) ? Pitch - 360 : Pitch;

		Roll = transform.eulerAngles.z;
		Roll = (Roll > 180) ? Roll - 360 : Roll;

		Yaw = transform.eulerAngles.y;
		Yaw = (Yaw > 180) ? Yaw - 360 : Yaw;

		Altitude = transform.position.y;

		VelocityVector = transform.GetComponent<Rigidbody>().velocity;
		VelocityScalar = VelocityVector.magnitude;
	}

	public void Reset()
	{
		Pitch = 0.0f;
		Roll = 0.0f;
		Yaw = 0.0f;
		Altitude = 1.0f;
	}
}