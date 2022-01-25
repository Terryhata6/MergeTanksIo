using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraExtension
{
    public static bool isGameObjectVisible(this UnityEngine.Camera @this, Renderer render)
    {
        return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(@this), render.bounds);
    }
}
