using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Test_Velocity : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 velocity;
    public Vector3 angularVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.rb.linearVelocity = this.velocity;
        this.rb.angularVelocity = this.angularVelocity;
    }
}
