using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Vector3 move;

    void Update()
    {
        transform.position += move * Time.deltaTime;
    }
}
