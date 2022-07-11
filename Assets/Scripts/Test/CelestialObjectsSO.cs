using UnityEngine;

[CreateAssetMenu]
public class CelestialObjectsSO : ScriptableObject
{
    public CelestialObject[] celestialObjects;

    [System.Serializable]
    public class CelestialObject
    {
        public string name;
        public float diameter;
        public float mass;
        public Vector3 position;
        public float axialTilt;
        //[Space]
        //public float inclinationAngle;
        //public float surfaceGravity;
    }
}
