using UnityEngine;

public class KinematicSeek: IKinematicMovement
{
    #region Variables
    public AgentController agent;
    public GameObject target;

    private string name = "Kinematic Seek";
    #endregion

    #region Constructors
    public KinematicSeek(AgentController agent, GameObject target)
    {
        this.agent = agent;
        this.target = target;
    }

    public KinematicSeek(AgentController agent)
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

        // Get direction towards the target
        steering.linear = this.target.transform.position - this.agent.transform.position;

        // Move full speed in this direction
        steering.linear.Normalize();
        steering.linear *= this.agent.MaxSpeed;

        // Update the agent's orientation to look in the direction of movement
        if (steering.linear != Vector3.zero)
        {
            this.agent.transform.forward = steering.linear.normalized;
        }

        Debug.DrawLine(this.agent.transform.position, this.agent.transform.position + steering.linear, Color.red);

        return steering;
    }
}