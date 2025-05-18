using _Main.Scripts.SurfaceArea;
using UnityEngine;

namespace _Main.Scripts.InspectionScene
{
    public class SquareSurfaceAreaManager : SurfaceAreaManager
    {
        [SerializeField] private CubeInspectionTarget cubeInspectionTarget;
        private SquareSurfaceAreaCalculator _surfaceAreaCalculator;
        
        protected override int GetSurfaceArea()
        {
            _surfaceAreaCalculator = new SquareSurfaceAreaCalculator(cubeInspectionTarget.ASliderManager.CurrentVal);
            return _surfaceAreaCalculator.GetSurfaceArea();
        }
    }
}