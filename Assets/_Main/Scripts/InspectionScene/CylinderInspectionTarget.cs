using _Main.Scripts.Projection;
using _Main.Scripts.Resize;
using _Main.Scripts.TSA;
using _Main.Scripts.Volume;
using UnityEngine;

namespace _Main.Scripts.InspectionScene
{
    public class CylinderInspectionTarget : InspectionTarget
    {
        [SerializeField] private ValueSliderStruct rSliderStruct, hSliderStruct;
        
        private SliderManager rSliderManager, hSliderManager;

        private ProjectionManager _projectionManager;
        
        public override ProjectionManager ProjectionManager => _projectionManager;

        private void Start()
        {
            _projectionManager = new ProjectionManager(animator);

            rSliderManager = new SliderManager(rSliderStruct, "r");
            hSliderManager = new SliderManager(hSliderStruct, "h");

            rSliderStruct.Slider.onValueChanged.AddListener(ResizeInspectionTarget);
            hSliderStruct.Slider.onValueChanged.AddListener(ResizeInspectionTarget);
        }
        
        protected override float GetVolume()
        {
            if (rSliderManager == null || hSliderManager == null)
            {
                return 0;
            }

            return VolumeCalculator.GetCylinderVolume(rSliderManager.CurrentVal, hSliderManager.CurrentVal);
        }

        protected override float GetTSA()
        {
            if (rSliderManager == null || hSliderManager == null)
            {
                return 0;
            }

            return TSACalculator.GetCylinderTSA(rSliderManager.CurrentVal, hSliderManager.CurrentVal);
        }

        protected override void ResizeInspectionTarget(float _)
        {
            Resizer.ResizeCylinder(tr, rSliderManager.CurrentVal, hSliderManager.CurrentVal, rSliderStruct.DefaultValue,
                hSliderStruct.DefaultValue);
        }

        protected override void RecalculateSurfaceAreas(float _)
        {
            throw new System.NotImplementedException();
        }
    }
}