using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public struct NBodyPhysics
{
    public static Vector3d CalculateForceOfGravity(Vector3d originBodyPos, double originBodyMass, Vector3d actingBodyPos, double actingBodyMass)
    {
        //Get the direction of the force 
        Vector3d direction = (actingBodyPos - originBodyPos).normalized;
        //Force Equation | F=G*M1*M2/(R^2)
        double force = NBodySimulation.G * (originBodyMass * actingBodyMass / (Vector3d.Distance(originBodyPos, actingBodyPos) * Vector3d.Distance(originBodyPos, actingBodyPos)));
        return force * direction;
    }
}
