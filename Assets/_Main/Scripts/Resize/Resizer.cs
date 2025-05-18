using Unity.VisualScripting;
using UnityEngine;

namespace _Main.Scripts.Resize
{
    public static class Resizer
    {
        public static void ResizeCube(Transform resizeTr, float a, float defaultA)
        {
            resizeTr.localScale = Vector3.one * a / defaultA;
        }
        
        public static void ResizeSphere(Transform resizeTr, float r, float defaultR)
        {
            resizeTr.localScale = Vector3.one * r / defaultR;
        }

        public static void ResizeRectangularPrism(Transform resizeTr, float w, float l, float h, float defaultW,
            float defaultL, float defaultH)
        {
            var xScale = l / defaultL;
            var yScale = h / defaultH;
            var zScale = w / defaultW;
            resizeTr.localScale = new Vector3(xScale, yScale, zScale);
        }

        public static void ResizeCone(Transform resizeTr, float r, float h, float defaultR, float defaultH)
        {
            var xScale = r / defaultR;
            var yScale = h / defaultH;

            resizeTr.localScale = new Vector3(xScale, yScale, xScale);
        }
        
        public static void ResizeTriangularPrism(Transform resizeTr, float b, float h, float l, float defaultB,
            float defaultH, float defaultL)
        {
            var xScale = b / defaultB;
            var yScale = h / defaultH;
            var zScale = l / defaultL;
            resizeTr.localScale = new Vector3(xScale, yScale, zScale);
        }
        
        public static void ResizeCylinder(Transform resizeTr, float r, float h, float defaultR, float defaultH)
        {
            var xScale = r / defaultR;
            var yScale = h / defaultH;

            resizeTr.localScale = new Vector3(xScale, yScale, xScale);
        }
    }
}