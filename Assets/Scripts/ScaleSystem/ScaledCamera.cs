using UnityEngine;

public class ScaledCamera : MonoBehaviour
{
    public Camera localCamera;
    public float unscaledFarClipPlane = 1e6f;
    public float nearClipOffset = 1f;

    Camera scaledCamera;

    void Start()
    {
        scaledCamera = GetComponent<Camera>();
    }

    void Update()
    {
        transform.position = FloatingOrigin.Instance.currentPosition / NBodySimulation.Instance.scale;
        transform.rotation = localCamera.transform.rotation;

        scaledCamera.nearClipPlane = (localCamera.farClipPlane * nearClipOffset) / NBodySimulation.Instance.scale;
        scaledCamera.farClipPlane = unscaledFarClipPlane / NBodySimulation.Instance.scale;
    }
}
