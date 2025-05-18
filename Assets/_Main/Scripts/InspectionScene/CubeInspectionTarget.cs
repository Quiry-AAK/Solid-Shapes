using System;
using System.Collections.Generic;
using _Main.Scripts.Projection;
using _Main.Scripts.Resize;
using _Main.Scripts.TSA;
using _Main.Scripts.Volume;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.InspectionScene
{
    public class CubeInspectionTarget : InspectionTarget
    {
        [SerializeField] private List<SquareSurfaceAreaManager> squareSurfaceAreaManagers;
        [Space]
        [SerializeField] private ValueSliderStruct aSliderStruct;
        
        private SliderManager aSliderManager;
        private ProjectionManager _projectionManager;

        public override ProjectionManager ProjectionManager => _projectionManager;

        public SliderManager ASliderManager => aSliderManager;

        private void Start()
        {
            aSliderManager = new SliderManager(aSliderStruct, "a");
            aSliderStruct.Slider.onValueChanged.AddListener(ResizeInspectionTarget);
            aSliderStruct.Slider.onValueChanged.AddListener(RecalculateSurfaceAreas);
            RecalculateSurfaceAreas(0f);
            _projectionManager = new ProjectionManager(animator);
        }

        protected override float GetVolume()
        {
            if (aSliderManager == null)
            {
                return 0;
            }

            return VolumeCalculator.GetCubeVolume(aSliderManager.CurrentVal);
        }

        protected override float GetTSA()
        {
            if (aSliderManager == null)
            {
                return 0;
            }

            return TSACalculator.GetCubeTSA(aSliderManager.CurrentVal);
        }

        protected override void ResizeInspectionTarget(float _)
        {
            Resizer.ResizeCube(tr, aSliderManager.CurrentVal, aSliderStruct.DefaultValue);
        }

        protected override void RecalculateSurfaceAreas(float _)
        {
            foreach (var squareSurfaceAreaManager in squareSurfaceAreaManagers)
            {
                squareSurfaceAreaManager.UpdateResultTxt();
            }
        }
    }
}