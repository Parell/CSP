using UnityEngine;

public class CelestialObjectGenerator : MonoBehaviour
{
    public CelestialObjectsSO celestialObjectsSO;
    public GameObject baseObject;

    public Transform scaledSpace;
    public Transform localSpace;

    void Start()
    {
        for (int i = 0; i < celestialObjectsSO.celestialObjects.Length; i++)
        {
            baseObject.name = celestialObjectsSO.celestialObjects[i].name;
            baseObject.transform.localScale = new Vector3(
            celestialObjectsSO.celestialObjects[i].diameter,
            celestialObjectsSO.celestialObjects[i].diameter,
            celestialObjectsSO.celestialObjects[i].diameter);

            Instantiate(baseObject, celestialObjectsSO.celestialObjects[i].position, Quaternion.identity, localSpace);
        }

        for (int i = 0; i < celestialObjectsSO.celestialObjects.Length; i++)
        {
            baseObject.name = celestialObjectsSO.celestialObjects[i].name;
            baseObject.transform.localScale = new Vector3(
            celestialObjectsSO.celestialObjects[i].diameter * ScaledSpace.Instance.scale,
            celestialObjectsSO.celestialObjects[i].diameter * ScaledSpace.Instance.scale,
            celestialObjectsSO.celestialObjects[i].diameter * ScaledSpace.Instance.scale);

            Instantiate(baseObject, celestialObjectsSO.celestialObjects[i].position * ScaledSpace.Instance.scale, Quaternion.identity, scaledSpace);
        }

        Transform[] list = scaledSpace.GetComponentsInChildren<Transform>();

        for (int i = 1; i < list.Length; i++)
        {
            ScaledSpace.Instance.RegisterFloatingOrigin(list[i]);
        }
    }
}
