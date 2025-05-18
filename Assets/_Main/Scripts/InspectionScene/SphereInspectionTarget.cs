using System;
using _Main.Scripts.Projection;
using _Main.Scripts.Resize;
using _Main.Scripts.TSA;
using _Main.Scripts.Volume;
using UnityEngine;

namespace _Main.Scripts.InspectionScene
{
    public class SphereInspectionTarget : InspectionTarget
    {
        [SerializeField] private ValueSliderStruct rSliderStruct;
        private SliderManager rSliderManager;
        public override ProjectionManager ProjectionManager { get; }

        private void Start()
        {
            rSliderManager = new SliderManager(rSliderStruct, "r");

            rSliderStruct.Slider.onValueChanged.AddListener(ResizeInspectionTarget);
        }

        protected override float GetVolume()
        {
            if (rSliderManager == null)
            {
                return 0;
            }

            return VolumeCalculator.GetSphereVolume(rSliderManager.CurrentVal);
        }

        protected override float GetTSA()
        {
            if (rSliderManager == null)
            {
                return 0;
            }

            return TSACalculator.GetSphereTSA(rSliderManager.CurrentVal);
        }

        protected override void ResizeInspectionTarget(float _)
        {
            Resizer.ResizeSphere(tr, rSliderManager.CurrentVal, rSliderStruct.DefaultValue);
        }

        protected override void RecalculateSurfaceAreas(float _)
        {
            throw new System.NotImplementedException();
        }
    }
}