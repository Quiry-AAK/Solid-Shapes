using System;
using _Main.Scripts.Projection;
using _Main.Scripts.Resize;
using _Main.Scripts.TSA;
using _Main.Scripts.Volume;
using TMPro;
using UnityEngine;

namespace _Main.Scripts.InspectionScene
{
    public class TriangularPrismInspectionTarget : InspectionTarget
    {
        [SerializeField] private ValueSliderStruct bSliderStruct, hSliderStruct, lSliderStruct;
        [SerializeField] private TextMeshProUGUI s1Txt, s2Txt;

        private SliderManager bSliderManager, hSliderManager, lSliderManager;

        private float s;

        private ProjectionManager _projectionManager;
        public override ProjectionManager ProjectionManager => _projectionManager;

        private void Start()
        {
            _projectionManager = new ProjectionManager(animator);

            bSliderManager = new SliderManager(bSliderStruct, "b");
            hSliderManager = new SliderManager(hSliderStruct, "h");
            lSliderManager = new SliderManager(lSliderStruct, "l");

            bSliderStruct.Slider.onValueChanged.AddListener(ResizeInspectionTarget);
            hSliderStruct.Slider.onValueChanged.AddListener(ResizeInspectionTarget);
            lSliderStruct.Slider.onValueChanged.AddListener(ResizeInspectionTarget);

            bSliderStruct.Slider.onValueChanged.AddListener(UpdateS);
            hSliderStruct.Slider.onValueChanged.AddListener(UpdateS);

            UpdateS(0);
        }

        private void UpdateS(float _)
        {
            if (bSliderManager == null || hSliderManager == null || lSliderManager == null)
            {
                return;
            }

            s = Mathf.Sqrt(Mathf.Pow(bSliderManager.CurrentVal / 2f, 2) + Mathf.Pow((hSliderManager.CurrentVal), 2));
            s1Txt.text = "s1 = " + s.ToString("F1");
            s2Txt.text = "s2 = " + s.ToString("F1");
        }

        protected override float GetVolume()
        {
            if (bSliderManager == null || hSliderManager == null || lSliderManager == null)
            {
                return 0;
            }

            return VolumeCalculator.GetTriangularPrismVolume(bSliderManager.CurrentVal, hSliderManager.CurrentVal,
                lSliderManager.CurrentVal);
        }

        protected override float GetTSA()
        {
            if (bSliderManager == null || hSliderManager == null || lSliderManager == null)
            {
                return 0;
            }

            return TSACalculator.GetTriangularPrismTSA(bSliderManager.CurrentVal, hSliderManager.CurrentVal,
                lSliderManager.CurrentVal, s);
        }

        protected override void ResizeInspectionTarget(float _)
        {
            Resizer.ResizeTriangularPrism(tr, bSliderManager.CurrentVal, hSliderManager.CurrentVal,
                lSliderManager.CurrentVal, bSliderStruct.DefaultValue, hSliderStruct.DefaultValue,
                lSliderStruct.DefaultValue);
        }

        protected override void RecalculateSurfaceAreas(float _)
        {
            throw new NotImplementedException();
        }
    }
}