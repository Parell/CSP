using UnityEngine;

public class Thruster : MonoBehaviour
{
    public Vector3 force;
    public bool isForce;

    ParticleSystem particleSource;
    //private Light lightSource;
    Vessel vessel;

    [SerializeField] bool isOn;
    string identifier;

    void Awake()
    {
        particleSource = GetComponent<ParticleSystem>();
        vessel = GetComponentInParent<Vessel>();

        identifier = GetInstanceID().ToString();
    }

    public void StartThruster()
    {
        if (!isOn)
        {
            particleSource.Play();

            if (isForce)
            {
                vessel.AddForce(identifier, force);
            }
            else
            {
                vessel.AddTorque(identifier, force);
            }

            isOn = true;
        }
    }

    public void StopThruster()
    {
        if (isOn)
        {
            particleSource.Stop();

            if (isForce)
            {
                vessel.RemoveForce(identifier);
            }
            else
            {
                vessel.RemoveTorque(identifier);
            }

            isOn = false;
        }
    }
}
