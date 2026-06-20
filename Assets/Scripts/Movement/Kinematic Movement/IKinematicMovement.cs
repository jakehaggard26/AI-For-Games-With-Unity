using UnityEngine;

public interface IKinematicMovement
{
    public string Name { get; }
    public SteeringOutput getSteering();
}
