using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Views.UI.ComputerControlPanel.ComputerHealthbar
{

    public class ComputerHealthbarView : MonoBehaviour
    {
        [SerializeField] private Image _healthbarImage;
        [SerializeField] private float _animationDuration;

        public void UpdateVisual(float value)
        {
            _healthbarImage.DOFillAmount(value/100, _animationDuration);
        }
    }

}