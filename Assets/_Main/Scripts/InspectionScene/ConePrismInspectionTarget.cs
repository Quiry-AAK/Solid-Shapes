using System;
using _Main.Scripts.Projection;
using _Main.Scripts.Resize;
using _Main.Scripts.TSA;
using _Main.Scripts.Volume;
using TMPro;
using UnityEngine;

namespace _Main.Scripts.InspectionScene
{
    public class ConePrismInspectionTarget : InspectionTarget
    {
        [SerializeField] private ValueSliderStruct rSliderStruct, hSliderStruct;
        [SerializeField] private TextMeshProUGUI lValueTxt;
        private SliderManager rSliderManager, hSliderManager;
        
        private ProjectionManager _projectionManager;

        private float l;
        public override ProjectionManager ProjectionManager => _projectionManager;

        private void Start()
        {
            _projectionManager = new ProjectionManager(animator);

            rSliderManager = new SliderManager(rSliderStruct, "r");
            hSliderManager = new SliderManager(hSliderStruct, "h");

            rSliderStruct.Slider.onValueChanged.AddListener(ResizeInspectionTarget);
            rSliderStruct.Slider.onValueChanged.AddListener(UpdateL);
            hSliderStruct.Slider.onValueChanged.AddListener(ResizeInspectionTarget);
            hSliderStruct.Slider.onValueChanged.AddListener(UpdateL);

            UpdateL(0);
        }

        protected override float GetVolume()
        {
            if (rSliderManager == null || hSliderManager == null)
            {
                return 0;
            }

            return VolumeCalculator.GetConeVolume(rSliderManager.CurrentVal, hSliderManager.CurrentVal);
        }

        protected override float GetTSA()
        {
            if (rSliderManager == null || hSliderManager == null)
            {
                return 0;
            }

            return TSACalculator.GetConeTSA(rSliderManager.CurrentVal, hSliderManager.CurrentVal);
        }

        protected override void ResizeInspectionTarget(float _)
        {
            Resizer.ResizeCone(tr, rSliderManager.CurrentVal, hSliderManager.CurrentVal, rSliderStruct.DefaultValue,
                hSliderStruct.DefaultValue);
        }

        protected override void RecalculateSurfaceAreas(float _)
        {
            throw new System.NotImplementedException();
        }

        private void UpdateL(float _)
        {
            if (rSliderManager == null || hSliderManager == null)
            {
                return;
            }

            l = Mathf.Sqrt(Mathf.Pow(rSliderManager.CurrentVal, 2) + Mathf.Pow((hSliderManager.CurrentVal), 2));
            lValueTxt.text = "l = " + l.ToString("F1");
        }
    }
}