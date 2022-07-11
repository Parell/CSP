using UnityEngine;

public class ScaledCamera : MonoBehaviour
{
    public Camera mainCamera;
    public double unscaledFarClipPlane = 1e6;
    public double nearClipOffset = .99;

    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        transform.localPosition = (ScaledSpace.Instance.cameraPosition * ScaledSpace.Instance.scale);
        transform.localRotation = mainCamera.transform.rotation;

        cam.nearClipPlane = (float)(mainCamera.farClipPlane * ScaledSpace.Instance.scale * nearClipOffset);
        cam.farClipPlane = (float)(unscaledFarClipPlane * ScaledSpace.Instance.scale);
        cam.fieldOfView = mainCamera.fieldOfView;
        cam.allowHDR = mainCamera.allowHDR;
        cam.allowMSAA = mainCamera.allowMSAA;
        cam.targetDisplay = mainCamera.targetDisplay;
        cam.renderingPath = mainCamera.renderingPath;
        cam.stereoTargetEye = mainCamera.stereoTargetEye;
        cam.targetTexture = mainCamera.targetTexture;
        cam.aspect = mainCamera.aspect;
    }
}
