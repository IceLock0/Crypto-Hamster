using System;
using TMPro;
using UnityEngine;

namespace Views.Hamster.Buttons
{
    public class HamsterUIButtonHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        [SerializeField] private string _textFormat = "{0:f5}";
        
        [SerializeField] private HamsterButtonType hamsterButtonType;

        [SerializeField] private float _buttonScaleFactor;

        public event Action<HamsterButtonType> ButtonPressed;

        public HamsterButtonType HamsterButtonType => hamsterButtonType;
        
        private HamsterOnClickButton _button;

        public void SetAmountText(float value)
        {
            _text.text = String.Format(_textFormat, value);
        }
        
        private void Awake()
        {
            _button = GetComponent<HamsterOnClickButton>();
        }

        private void ButtonDown()
        {
            gameObject.transform.localScale *= _buttonScaleFactor;
        }

        private void ButtonUp()
        {
            gameObject.transform.localScale /= _buttonScaleFactor;

            ButtonPressed?.Invoke(hamsterButtonType);
        }
        
        private void OnEnable()
        {
            _button.OnButtonDownClicked += ButtonDown;
            _button.OnButtonUpClicked += ButtonUp;
        }

        private void OnDisable()
        {
            _button.OnButtonDownClicked -= ButtonDown;
            _button.OnButtonUpClicked -= ButtonUp;
        }
    }
}