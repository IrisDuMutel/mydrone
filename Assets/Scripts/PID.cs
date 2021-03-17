[System.Serializable]

// used by ComputerModule.cs 
public class PID 
{
    public float pFactor, iFactor, dFactor;

    float integral;
    float lastError;

    // Introduce factor to class
    public PID(float pFactor, float iFactor, float dFactor)
    {
        this.pFactor = pFactor;
        this.iFactor = iFactor;
        this.dFactor = dFactor;
    }

    // Actual PID computation
    public float Update(float setpoint, float actual, float timeFrame)
    {
        float present = setpoint - actual; // computes the error
        integral += present * timeFrame;   // computes the integral 
        float deriv = (present - lastError) / timeFrame; // computes the derivative
        lastError = present;  // updates the error
        float finalPID = present * pFactor + integral * iFactor + deriv * dFactor; // computes PID
        if ((finalPID > -0.1) && (finalPID < 0.1))
            finalPID = 0;
        return finalPID;
    }

    public void Reset()
    {
        integral = 0.0f;
        lastError = 0.0f;
    }
}
