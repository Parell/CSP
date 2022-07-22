using Unity.Collections;
using UnityEngine;

public class NBodySimulation : MonoBehaviour
{
    public static NBodySimulation Instance;

    public const double G = 0.00000000006673;

    public OrbitalBodySO[] orbitalBodiesSO;
    public GameObject[] scaledBodyObjects;
    public GameObject[] localBodyObjects;

    private NativeArray<OrbitalBody> orbitalBodies;
    public float scale;
    public int lossLessTimeScale;
    public int lossyTimeScale;

    private void Awake()
    {
        Instance = this;

/*         for (int i = 0; i < orbitalBodyObjectsR.Length; i++)
        {
            FloatingOrigin.Instance.RegisterFloatingOrigin(orbitalBodyObjectsR[i].transform);
        } */

        orbitalBodies = new NativeArray<OrbitalBody>(orbitalBodiesSO.Length, Allocator.Persistent);
        for (int i = 0; i < orbitalBodiesSO.Length; i++)
        {
            orbitalBodies[i] = new OrbitalBody()
            {
                orbitalData = new OrbitalData(orbitalBodiesSO[i]),
                planetaryData = new PlanetaryData(orbitalBodiesSO[i]),
                index = i,
            };
        }
    }

    private void Update()
    {
        UpdateSystem();
        for (int i = 0; i < orbitalBodies.Length; i++)
            DrawBody(i);
    }

    private void EndSimulation()
    {
        orbitalBodies.Dispose();
    }

    private void DrawBody(int i)
    {
        scaledBodyObjects[i].transform.localPosition = (orbitalBodies[i].orbitalData.position / scale).ToVector3();
        localBodyObjects[i].transform.localPosition = (scaledBodyObjects[i].transform.position * scale);

        scaledBodyObjects[i].transform.localScale = Vector3.one * (float)(orbitalBodies[i].planetaryData.radius / scale);
        localBodyObjects[i].transform.localScale = Vector3.one * (float)orbitalBodies[i].planetaryData.radius;
    }

    private void UpdateSystem()
    {
        for (int i = 0; i < lossLessTimeScale; i++)
        {
            for (int j = 0; j < orbitalBodies.Length; j++)
            {
                var orbitalBody = orbitalBodies[j];
                orbitalBody.CalculateForces(orbitalBodies);
                orbitalBodies[j] = orbitalBody;
            }

            for (int j = 0; j < orbitalBodies.Length; j++)
            {
                var orbitalBody = orbitalBodies[j];
                orbitalBody.ApplyForces(lossyTimeScale * Time.deltaTime);
                orbitalBodies[j] = orbitalBody;
            }
        }
    }
}
