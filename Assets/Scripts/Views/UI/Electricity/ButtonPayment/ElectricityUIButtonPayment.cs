using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views.UI.Electricity.ButtonPayment
{
    public class ElectricityUIButtonPayment : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public event Action ButtonClicked;

        private void OnEnable()
        {
            _button.onClick.AddListener(Click);
            
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Click);
        }

        private void Click()
        {
            ButtonClicked?.Invoke();
        }
    }
}