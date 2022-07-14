using UnityEngine;

public class Part : MonoBehaviour
{
    public Rigidbody rb;

/*     [Tooltip("Current mass of part and its resources")]
    public float mass;
    [Tooltip("Mass of part if all resources were empty")]
    public float dryMass;
    [Tooltip("Mass of part if all resources were full")]
    public float wetMass; */
    [Space]
    public float health;
    public float temp;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();

/*         mass = wetMass;

        rb.mass += mass; */
    }
}
