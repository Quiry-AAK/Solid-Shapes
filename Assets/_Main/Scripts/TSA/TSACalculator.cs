using UnityEngine;

namespace _Main.Scripts.TSA
{
    public static class TSACalculator
    {
        public static float GetCubeTSA(float a)
        {
            return 6 * Mathf.Pow(a, 2);
        }

        public static float GetRectangularPrismTSA(float w, float l, float h)
        {
            return 2 * (w * l + l * h + h * w);
        }

        public static float GetSphereTSA(float r)
        {
            return 4f * Mathf.PI * Mathf.Pow(r, 2);
        }

        public static float GetConeTSA(float r, float h)
        {
            return Mathf.PI * r * (r + Mathf.Sqrt(Mathf.Pow(r, 2) + Mathf.Pow(h, 2)));
        }

        public static float GetPyramidTSA(float l, float w, float h)
        {
            var p1 = l * w;
            var p2 = l * Mathf.Sqrt(Mathf.Pow(w / 2f, 2) + Mathf.Pow(h, 2));
            var p3 = w * Mathf.Sqrt(Mathf.Pow(l / 2f, 2) + Mathf.Pow(h, 2));

            return p1 + p2 + p3;
        }

        public static float GetTriangularPrismTSA(float b, float h, float l, float s)
        {
            return b * h + (s + s + b) * l;
        }

        public static float GetCylinderTSA(float r, float h)
        {
            return Mathf.PI * Mathf.Pow(r, 2) + 2 * Mathf.PI * r * h;
        }
    }
}