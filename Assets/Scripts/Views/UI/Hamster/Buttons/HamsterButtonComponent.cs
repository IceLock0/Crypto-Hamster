using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;

namespace Views.Hamster
{
    [AddComponentMenu("Input/On-Screen Button Hamster Component")]
    public class HamsterButtonComponent : OnScreenControl, IPointerDownHandler, IPointerUpHandler
    {
        [InputControl(layout = "Button")]
        [SerializeField] private string _controlPath;

        [SerializeField] private HamsterButtonType _buttonType;

        [SerializeField] private float _buttonScaleFactor;
        
        public event Action<HamsterButtonType> OnButtonDownClicked;
        public event Action<HamsterButtonType> OnButtonUpClicked;

        protected override string controlPathInternal { get => _controlPath; set => _controlPath = value; }

        public HamsterButtonType ButtonType => _buttonType;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            gameObject.transform.localScale *= _buttonScaleFactor;
            
            SendValueToControl(1.0f);
            
            OnButtonDownClicked?.Invoke(_buttonType);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            gameObject.transform.localScale /= _buttonScaleFactor;
            
            SendValueToControl(0.0f);
            
            OnButtonUpClicked?.Invoke(_buttonType);
        }
    }
}