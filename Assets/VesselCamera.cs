using UnityEngine;

public class VesselCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float followSpeed = 5;
    public float lookSpeed = 20;

    Vector3 orbit;
    Quaternion targetRotation;
    Vector3 targetPosition;

    void FixedUpdate()
    {
        Orbit();
        MoveToTarget();
        LookAtTarget();
    }

    void MoveToTarget()
    {
        targetPosition = Quaternion.Euler(orbit.x, orbit.y, 0) * offset;
        targetPosition += target.position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }

    void LookAtTarget()
    {
        targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookSpeed * Time.deltaTime);
    }

    void Orbit()
    {
        if (Input.GetMouseButton(1))
        {
            orbit.x -= Input.GetAxisRaw("Mouse Y") * 5;
            orbit.y += Input.GetAxisRaw("Mouse X") * 5;
        }
    }
}
