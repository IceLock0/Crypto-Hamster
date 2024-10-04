using UnityEngine;
using UnityEngine.UI;

namespace Views.UI.ComputerControlPanel.ComputerHealthbar
{

    public class ComputerHealthbarView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private float _animationDuration;

        public void UpdateVisual(float value)
        {
            _slider.value = Mathf.Clamp(value, _slider.minValue, _slider.maxValue);
        }
    }

}