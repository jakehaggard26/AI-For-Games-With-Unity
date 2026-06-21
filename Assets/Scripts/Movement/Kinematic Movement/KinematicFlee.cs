using UnityEngine;

public class KinematicFlee: IKinematicMovement
{
    #region Variables
    public AgentController agent;
    public GameObject target;

    private string name = "Kinematic Flee";
    #endregion

    #region Constructors
    public KinematicFlee(AgentController agent, GameObject target)
    {
        this.agent = agent;
        this.target = target;
    }

    public KinematicFlee(AgentController agent)
    {
        this.agent = agent;
        this.target = null;
    }
    #endregion

    #region Properties
    public string Name
    {
        get => this.name;
    }
    #endregion


    public SteeringOutput getSteering()
    {
        SteeringOutput steering = new SteeringOutput();

        // Get direction away from the target
        steering.linear = this.agent.transform.position - this.target.transform.position;

        // Move full speed in this direction
        steering.linear.Normalize();
        steering.linear *= this.agent.MaxSpeed;

        // Update the agent's orientation to look in the direction of movement
        if (steering.linear != Vector3.zero)
        {
            steering.angular = this.agent.transform.forward = steering.linear.normalized;
        }

        Debug.DrawLine(this.agent.transform.position, this.agent.transform.position + steering.linear, Color.red);

        return steering;
    }
}