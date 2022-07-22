using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct OrbitalData
{
    public Vector3d position;
    public Vector3d velocity;

    public double orbitalRadius;
    public double orbitalVelocity;
    public double inclination;
    //Unused
    public float eccentricity;

    public OrbitalData(OrbitalBodySO so)
    {
        position = so.GetAbsolutePositionVector();
        velocity = so.GetAbsoluteVelocityVector();

        orbitalRadius = so.orbitalRadius;
        orbitalVelocity = so.orbitalVelocity;
        inclination = so.inclination;
        eccentricity = so.eccentricity;
    }
}