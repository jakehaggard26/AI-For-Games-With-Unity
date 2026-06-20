using UnityEngine;

public class SteeringOutput
{
    public Vector3 linear;
    public Vector3 angular;


    public SteeringOutput()
    {
        this.linear = Vector3.zero;
        this.angular = Vector3.zero;
    }

    public SteeringOutput(Vector3 linear, Vector3 angular)
    {
        this.linear = linear;
        this.angular = angular;
    }
}