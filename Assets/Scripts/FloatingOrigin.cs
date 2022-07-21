using System.Collections.Generic;
using UnityEngine;

public class FloatingOrigin : MonoBehaviour
{
    public static FloatingOrigin Instance;

    public Transform target;
    public float maxOriginDistance = 6000f;
    public float maxVelocity = 10000f;
    public Vector3 currentPosition;
    public Vector3 originPosition;
    public List<Transform> moveWithOrigin;

    Rigidbody targetRigidbody;

    void Awake()
    {
        Instance = this;

        targetRigidbody = target.GetComponent<Rigidbody>();

        RegisterFloatingOrigin(target);
    }

    void Update()
    {
        currentPosition = target.position + originPosition;

        if (target.position.magnitude > maxOriginDistance)
        {
            MoveOrigin(target.position);
        }

        if (targetRigidbody.velocity.magnitude > maxVelocity)
        {
            Debug.Log("MoveVelocityReferanceFrame");

            //MoveVelocityReferanceFrame
            //zero out velocity pass the velocity to the referance frame
            //to slow down move velocity on referance frame back to rigidbody
        }
    }

    void MoveOrigin(Vector3 delta)
    {
        foreach (Transform target in moveWithOrigin)
        {
            target.position -= delta;
        }

        originPosition += delta;
    }

    public void RegisterFloatingOrigin(Transform target)
    {
        moveWithOrigin.Add(target);
    }

    public void UnregisterFloatingOrigin(Transform target)
    {
        moveWithOrigin.Remove(target);
    }
}
