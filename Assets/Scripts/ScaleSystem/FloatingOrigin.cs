using System.Collections.Generic;
using UnityEngine;

public class FloatingOrigin : MonoBehaviour
{
    public static FloatingOrigin Instance;

    public Transform target;
    public Rigidbody targetRigidbody;
    public float maxOriginDistance = 6000f;
    public float maxVelocity = 10000f;
    public Vector3 currentPosition;
    public Vector3 originPosition;
    public List<Transform> moveWithOrigin;

    void Awake()
    {
        Instance = this;
    }

    public void MoveOriginButton()
    {
        MoveOrigin(target.position);
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
        // add a rigidbody exception for rb.position - stops jumpyness
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
