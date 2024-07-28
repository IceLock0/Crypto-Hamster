using System;
using Presenters.Hamster;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;

namespace Views.Hamster
{
    [AddComponentMenu("Input/On-Screen Button Hamster")]
    public class HamsterOnClickButton : OnScreenControl, IPointerDownHandler, IPointerUpHandler
    {
        [InputControl(layout = "Button")]
        [SerializeField] private string _controlPath;

        public event Action OnButtonDownClicked;
        public event Action OnButtonUpClicked;
        
        protected override string controlPathInternal { get => _controlPath; set => _controlPath = value; }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
        
            SendValueToControl(1.0f);

            OnButtonDownClicked?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
        
            SendValueToControl(0.0f);
        
            OnButtonUpClicked?.Invoke();
        }
    
    }
}
