using System;
using _Main.Scripts.Projection;
using _Main.Scripts.Resize;
using _Main.Scripts.TSA;
using _Main.Scripts.Volume;
using UnityEngine;

namespace _Main.Scripts.InspectionScene
{
    public class PyramidInspectionTarget : InspectionTarget
    {
        [SerializeField] private ValueSliderStruct hSliderStruct, lSliderStruct, wSliderStruct;

        private SliderManager hSliderManager, lSliderManager, wSliderManager;

        private ProjectionManager _projectionManager;
    
        public override ProjectionManager ProjectionManager => _projectionManager;

        private void Start()
        {
            _projectionManager = new ProjectionManager(animator);
            
            wSliderManager = new SliderManager(wSliderStruct, "w");
            lSliderManager = new SliderManager(lSliderStruct, "l");
            hSliderManager = new SliderManager(hSliderStruct, "h");

            wSliderStruct.Slider.onValueChanged.AddListener(ResizeInspectionTarget);
            lSliderStruct.Slider.onValueChanged.AddListener(ResizeInspectionTarget);
            hSliderStruct.Slider.onValueChanged.AddListener(ResizeInspectionTarget);
        }

        protected override float GetVolume()
        {
            if (wSliderManager == null || lSliderManager == null || hSliderManager == null)
            {
                return 0;
            }

            return VolumeCalculator.GetPyramidVolume(lSliderManager.CurrentVal, wSliderManager.CurrentVal,
                hSliderManager.CurrentVal);
        }

        protected override float GetTSA()
        {
            if (wSliderManager == null || lSliderManager == null || hSliderManager == null)
            {
                return 0;
            }

            return TSACalculator.GetPyramidTSA(lSliderManager.CurrentVal, wSliderManager.CurrentVal,
                hSliderManager.CurrentVal);
        }

        protected override void ResizeInspectionTarget(float _)
        {
            Resizer.ResizeRectangularPrism(tr, wSliderManager.CurrentVal,
                lSliderManager.CurrentVal,
                hSliderManager.CurrentVal, wSliderStruct.DefaultValue, lSliderStruct.DefaultValue,
                hSliderStruct.DefaultValue);
        }

        protected override void RecalculateSurfaceAreas(float _)
        {
            throw new System.NotImplementedException();
        }
    }
}