using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Elements
{
    public class SettingSliderElement : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        public event Action<float> OnSliderValueChange; 

        public void Init(float minValue, float maxValue, float value)
        {
            slider.minValue = minValue;
            slider.maxValue = maxValue;
            slider.SetValueWithoutNotify(value);
        }

        private void OnSliderValueChanged(float value)
        {
            OnSliderValueChange?.Invoke(value);
        }

        private void OnEnable()
        {
            slider.onValueChanged.AddListener(OnSliderValueChanged);
        }

        private void OnDisable()
        {
            slider.onValueChanged.RemoveListener(OnSliderValueChanged);
        }
    }
}
