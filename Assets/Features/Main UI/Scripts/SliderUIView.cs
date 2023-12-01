using UnityEngine;
using UnityEngine.UI;

namespace TestTask.UI.ProgressBar
{
    [RequireComponent(typeof(Slider))]
    public class SliderUIView : ObjectView
    {
        private Slider _slider;

        public void Initialize(float maxValue, float currentValue)
        {
            _slider = GetComponent<Slider>();
            _slider.maxValue = maxValue;
            UpdateValue(currentValue);
        }

        public void UpdateValue(float value)
        {
            _slider.value = value;
        }
    }
}
