using DG.Tweening;
using Model.Computer;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Zenject;

namespace Views.UI.ComputerControlPanel.ComputerHealthbar
{

    public class ComputerHealthbarView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private float _animationDuration;

        public void UpdateVisual(float value)
        {
            _slider.DOValue(Mathf.Clamp(value, _slider.minValue, _slider.maxValue), _animationDuration);
        }
    }

}