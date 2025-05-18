using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.InspectionScene
{
    [Serializable]
    public struct ValueSliderStruct
    {
        [SerializeField] private Slider slider;

        [SerializeField] private int defaultValue;
        [SerializeField] private float minValue, maxValue;
        
        [SerializeField] private TextMeshProUGUI sliderTxt;

        public Slider Slider => slider;

        public int DefaultValue => defaultValue;

        public float MinValue => minValue;

        public float MaxValue => maxValue;

        public TextMeshProUGUI SliderTxt => sliderTxt;
    }
}