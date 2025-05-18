using UnityEngine;

namespace _Main.Scripts.Volume
{
    public static class VolumeCalculator
    {
        public static float GetCubeVolume(float a)
        {
            return Mathf.Pow(a, 3);
        }

        public static float GetRectangularPrismVolume(float w, float l, float h)
        {
            return w * l * h;
        }

        public static float GetSphereVolume(float r)
        {
            return 4f / 3f * Mathf.PI * Mathf.Pow(r, 3);
        }

        public static float GetConeVolume(float r, float h)
        {
            return Mathf.PI * Mathf.Pow(r, 2) * h / 3f;
        }

        public static float GetPyramidVolume(float l, float w, float h)
        {
            return l * w * h / 3f;
        }

        public static float GetTriangularPrismVolume(float b, float h, float l)
        {
            return 1f / 2f * b * h * l;
        }
        
        public static float GetCylinderVolume(float r, float h)
        {
            return Mathf.PI * Mathf.Pow(r, 2) * h;
        }
    }
}