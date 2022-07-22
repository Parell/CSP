using UnityEngine;

public enum Resources
{
    Bullets, LH2, LOX, Missiles
}

public class Resource : Part
{
    [Space]
    public Resources resource;
    public float amount = 10f;
    public float density = 0.001f;
    public float capacity = 10f;

    void Update()
    {
/*         wetMass = dryMass + (amount * density);

        mass = wetMass; */
    }
}
