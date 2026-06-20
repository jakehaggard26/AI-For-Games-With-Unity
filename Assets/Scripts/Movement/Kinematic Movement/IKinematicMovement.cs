using UnityEngine;

public interface IKinematicMovement
{
    GameObject Agent { get; set; }
    GameObject Target { get; set; }
    public Vector3 getSteering(GameObject agent, GameObject target);
}
