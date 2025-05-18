using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.InspectionScene
{
    public class SliderManager
    {
        private string valueName;
        private TextMeshProUGUI sliderText;
        private Slider _slider;
        private int defaultVal;
        private float minVal, maxVal;

        private int currentVal;

        public int CurrentVal => currentVal;

        public SliderManager(ValueSliderStruct valueSliderStruct, string valueName)
        {
            _slider = valueSliderStruct.Slider;
            this.defaultVal = valueSliderStruct.DefaultValue;
            this.minVal = valueSliderStruct.MinValue;
            this.maxVal = valueSliderStruct.MaxValue;
            this.valueName = valueName;
            this.sliderText = valueSliderStruct.SliderTxt;
            
            _slider.onValueChanged.AddListener(OnSliderValueChanged);
            _slider.value = (this.defaultVal - this.minVal) / (this.maxVal - minVal);
        }

        private void OnSliderValueChanged(float newValue)
        {
            currentVal = Mathf.CeilToInt(minVal + newValue * (maxVal - minVal));
            sliderText.text = valueName + " = " + currentVal;
        }
    }
}