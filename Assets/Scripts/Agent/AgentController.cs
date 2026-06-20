using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AgentController : MonoBehaviour
{
    #region  Variables
    private Rigidbody rb;
    private Vector3 velocity;
    private Vector3 angularVelocity;
    #endregion
    
    #region  Properties
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
    #endregion

    #region Unity Methods
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();

        // Set the initial velocity and angular velocity to pre-set values (can be modified in the Inspector)
        this.rb.linearVelocity = this.velocity;
        this.rb.angularVelocity = this.angularVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        this.rb.linearVelocity = this.velocity;
        this.rb.angularVelocity = this.angularVelocity;
    }
    #endregion
}
