﻿/**
 * @author Valentin Simonov / http://va.lent.in/
 */

using UnityEngine;

namespace TouchScript.Utils
{
    public class ProjectionUtils
    {
        public static Vector3 CameraToPlaneProjection(Vector2 position, Camera camera, Plane projectionPlane)
        {
            var ray = camera.ScreenPointToRay(position);
            var relativeIntersection = 0f;
            projectionPlane.Raycast(ray, out relativeIntersection);
            return ray.origin + ray.direction*relativeIntersection;
        }
    }
}