using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AgentController : MonoBehaviour
{
    #region  Variables
    [SerializeField]
    private GameObject target;
    
    [SerializeField]
    private float maxSpeed = 7.5f;
    private Rigidbody rb;
    private Vector3 velocity;
    private Vector3 angularVelocity;

    private enum KinematicMovement
    {
        KinematicSeek,
        KinematicFlee,
        KinematicArrive,
        KinematicWander,
        None
    }
    [SerializeField]
    private KinematicMovement currentMovement = KinematicMovement.None;
    private SteeringOutput steering;
    #endregion
    
    #region  Properties
    public float MaxSpeed
    {
        get => this.maxSpeed;
        set => this.maxSpeed = value;
    }
    public Rigidbody Rb
    {
        get => this.rb;
        set => this.rb = value;
    }
    public Vector3 Velocity
    {
        get => this.velocity;
        set => this.velocity = value;
    }
    public Vector3 AngularVelocity
    {
        get => this.angularVelocity;
        set => this.angularVelocity = value;
    }

    public GameObject Target
    {
        get => this.target;
        set => this.target = value;
    }
    #endregion

    #region Unity Methods
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();

        // Set the initial velocity and angular velocity to pre-set values (can be modified in the Inspector)
        this.rb.linearVelocity = this.velocity;
        this.rb.angularVelocity = this.angularVelocity;

        steering = new SteeringOutput();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        // Get steering output
        switch (this.currentMovement)
        {
            case KinematicMovement.KinematicSeek:
                this.steering = new KinematicSeek(this, this.target).getSteering();
                break;
            case KinematicMovement.KinematicFlee:
                this.steering = new KinematicFlee(this, this.target).getSteering();
                break;
            default:
                break;
        }

        // Honestly, this is unnecessary (see next step)
        // this.velocity = this.steering.linear;
        // this.angularVelocity = this.steering.angular;

        // Update the Rigidbody's velocity and angular velocity based on the steering output
        // this.rb.linearVelocity = this.velocity;
        // this.rb.angularVelocity = this.angularVelocity;
        this.rb.linearVelocity = this.steering.linear;
        this.rb.angularVelocity = this.steering.angular;
    }
    #endregion
}
