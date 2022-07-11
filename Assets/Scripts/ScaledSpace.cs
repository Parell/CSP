using System.Collections.Generic;
using UnityEngine;

public class ScaledSpace : MonoBehaviour
{
    public static ScaledSpace Instance;

    public Camera mainCamera;
    //public float cameraPerspectiveScale;

    public float scale = 0.0001f;
    public Vector3 origin = Vector3.zero;
    public float maxOriginDistance = 6000;
    public Vector3 cameraPosition;

    public List<Transform> moveWithOrigin = new List<Transform>();

    public void MoveOriginButton()
    {
        MoveOrigin(mainCamera.transform.position);
    }

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        Instance = this;

        if (mainCamera.transform.position.magnitude > maxOriginDistance)
            MoveOrigin(mainCamera.transform.position);

        float hfov = Mathf.Rad2Deg * 2f * Mathf.Atan(Mathf.Tan(mainCamera.fieldOfView * Mathf.Deg2Rad * .5f) * mainCamera.aspect);
        //cameraPerspectiveScale = Screen.width / (2f * Mathf.Tan(hfov * .5f));
    }

    void LateUpdate()
    {
        cameraPosition = Camera.main.transform.position + origin;
    }

    public void MoveOrigin(Vector3 delta)
    {
        foreach (Transform t in moveWithOrigin)
        {
            t.position -= delta;
        }

        origin += delta;
    }

    public void RegisterFloatingOrigin(Transform t)
    {
        moveWithOrigin.Add(t);
    }

    public void UnregisterFloatingOrigin(Transform t)
    {
        moveWithOrigin.Remove(t);
    }
}

