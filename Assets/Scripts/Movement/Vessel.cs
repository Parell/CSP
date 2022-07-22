using System.Collections;
using UnityEngine;

public class Vessel : MonoBehaviour
{
    [System.Serializable]
    public class RollThrusters
    {
        public Thruster[] right;
        public Thruster[] left;
    }

    [System.Serializable]
    public class PitchThrusters
    {
        public Thruster[] up;
        public Thruster[] down;
    }

    [System.Serializable]
    public class YawThrusters
    {
        public Thruster[] right;
        public Thruster[] left;
    }

    [System.Serializable]
    public class MainThrusters
    {
        public Thruster[] main;
        public Thruster[] ullage;
    }

    public RollThrusters rollThrusters;
    public PitchThrusters pitchThrusters;
    public YawThrusters yawThrusters;
    public MainThrusters mainThrusters;

    public Hashtable torques;
    public Hashtable forces;

    new Rigidbody rigidbody;

    /*     public bool stabilityAssist;
        public float rollInput;
        public float pitchInput;
        public float yawInput;
        public float deadBand; */


/*     [SerializeField]
    [Range(-10, 10)]
    float _zAxisP, _zAxisI, _zAxisD;

    PIDSystem _zAxisPIDController; */

    void Start()
    {
        //FloatingOrigin.Instance.RegisterFloatingOrigin(this.transform);

        rigidbody = GetComponent<Rigidbody>();

        torques = new Hashtable();
        forces = new Hashtable();

/*         _zAxisPIDController = new PIDSystem(_zAxisP, _zAxisI, _zAxisD);
        _zAxisPIDController.derivativeMeasurement = PIDSystem.DerivativeMeasurement.ErrorRateOfChange; */
    }

    void Update()
    {
        HandleRoll();
        HandlePitch();
        HandleYaw();
        HandleMainThruster();
        //HandleStability();
    }

    void FixedUpdate()
    {
        HandleTorques();
        HandleForces();
    }

    void HandleRoll()
    {
        if (RollRight())
        {
            for (int i = 0; i < rollThrusters.right.Length; i++)
            {
                rollThrusters.right[i].StartThruster();
            }
            for (int i = 0; i < rollThrusters.left.Length; i++)
            {
                rollThrusters.left[i].StopThruster();
            }
        }
        else if (RollLeft())
        {
            for (int i = 0; i < rollThrusters.right.Length; i++)
            {
                rollThrusters.right[i].StopThruster();
            }
            for (int i = 0; i < rollThrusters.left.Length; i++)
            {
                rollThrusters.left[i].StartThruster();
            }
        }
        else
        {
            for (int i = 0; i < rollThrusters.right.Length; i++)
            {
                rollThrusters.right[i].StopThruster();
            }
            for (int i = 0; i < rollThrusters.left.Length; i++)
            {
                rollThrusters.left[i].StopThruster();
            }
        }
    }

    void HandlePitch()
    {
        if (PitchUp())
        {
            for (int i = 0; i < pitchThrusters.up.Length; i++)
            {
                pitchThrusters.up[i].StartThruster();
            }
            for (int i = 0; i < pitchThrusters.down.Length; i++)
            {
                pitchThrusters.down[i].StopThruster();
            }
        }
        else if (PitchDown())
        {
            for (int i = 0; i < pitchThrusters.up.Length; i++)
            {
                pitchThrusters.up[i].StopThruster();
            }
            for (int i = 0; i < pitchThrusters.down.Length; i++)
            {
                pitchThrusters.down[i].StartThruster();
            }
        }
        else
        {
            for (int i = 0; i < pitchThrusters.up.Length; i++)
            {
                pitchThrusters.up[i].StopThruster();
            }
            for (int i = 0; i < pitchThrusters.down.Length; i++)
            {
                pitchThrusters.down[i].StopThruster();
            }
        }
    }

    void HandleYaw()
    {
        if (YawRight())
        {
            for (int i = 0; i < yawThrusters.right.Length; i++)
            {
                yawThrusters.right[i].StartThruster();
            }
            for (int i = 0; i < yawThrusters.left.Length; i++)
            {
                yawThrusters.left[i].StopThruster();
            }
        }
        else if (YawLeft())
        {
            for (int i = 0; i < yawThrusters.right.Length; i++)
            {
                yawThrusters.right[i].StopThruster();
            }
            for (int i = 0; i < yawThrusters.left.Length; i++)
            {
                yawThrusters.left[i].StartThruster();
            }
        }
        else
        {
            for (int i = 0; i < yawThrusters.right.Length; i++)
            {
                yawThrusters.right[i].StopThruster();
            }
            for (int i = 0; i < yawThrusters.left.Length; i++)
            {
                yawThrusters.left[i].StopThruster();
            }
        }
    }

    void HandleMainThruster()
    {
        if (MainThruster())
        {
            for (int i = 0; i < mainThrusters.main.Length; i++)
            {
                mainThrusters.main[i].StartThruster();
            }
        }
        else
        {
            for (int i = 0; i < mainThrusters.main.Length; i++)
            {
                mainThrusters.main[i].StopThruster();
            }
        }
    }

    /*     void HandleStability()
        {
            _zAxisPIDController.proportionalGain = _zAxisP;
            _zAxisPIDController.integralGain = _zAxisI;
            _zAxisPIDController.derivativeGain = _zAxisD;

            if (stabilityAssist)
            {
                float zTorqueCorrection = _zAxisPIDController.Update(Time.fixedDeltaTime, rigidbody.angularVelocity.z, 0f);
                rollInput = zTorqueCorrection;
            }
        } */

    public void AddTorque(string identifier, Vector3 torque)
    {
        if (torques.ContainsKey(identifier)) return;
        torques.Add(identifier, torque);
    }

    public void RemoveTorque(string identifier)
    {
        if (!torques.ContainsKey(identifier)) return;
        torques.Remove(identifier);
    }

    public void AddForce(string identifier, Vector3 force)
    {
        if (forces.ContainsKey(identifier)) return;
        forces.Add(identifier, force);
    }

    public void RemoveForce(string identifier)
    {
        if (!forces.ContainsKey(identifier)) return;
        forces.Remove(identifier);
    }

    void HandleTorques()
    {
        foreach (DictionaryEntry entry in torques)
        {
            Vector3 torque = (Vector3)entry.Value;
            rigidbody.AddRelativeTorque(torque.normalized);
        }
    }

    void HandleForces()
    {
        foreach (DictionaryEntry entry in forces)
        {
            Vector3 force = (Vector3)entry.Value;
            rigidbody.AddRelativeForce(force);
        }
    }

    bool RollLeft()
    {
        if (Input.GetKey(KeyCode.Q)/*  || rollInput > deadBand */) return true; return false;
    }

    bool RollRight()
    {
        if (Input.GetKey(KeyCode.E)/*  || rollInput < -deadBand */) return true; return false;
    }

    bool PitchUp()
    {
        if (Input.GetKey(KeyCode.S)) return true; return false;
    }

    bool PitchDown()
    {
        if (Input.GetKey(KeyCode.W)) return true; return false;
    }

    bool YawLeft()
    {
        if (Input.GetKey(KeyCode.A)) return true; return false;
    }

    bool YawRight()
    {
        if (Input.GetKey(KeyCode.D)) return true; return false;
    }

    bool MainThruster()
    {
        if (Input.GetKey(KeyCode.Space)) return true; return false;
    }
}