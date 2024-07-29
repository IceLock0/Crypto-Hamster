﻿using System;
using System.Collections.Generic;
using Presenters.Hamster;
using UnityEngine;

namespace Views.Hamster
{
    public class HamsterUIView : MonoBehaviour
    {
        [SerializeField] private List<HamsterTextComponent> _textComponents;
        [SerializeField] private List<HamsterButtonComponent> _buttonComponents;

        public event Action Updated;
        public event Action MainButtonPressed;
        public event Action UpgradePerClickButtonPressed;
        public event Action UpgradePerTimeButtonPressed;

        private HamsterPresenter _presenter;
        
        public void SetText(HamsterTextType textType, float value)
        {
            foreach (var textComponent in _textComponents)
            {
                if (textComponent.TextType == textType)
                    textComponent.SetText(value);
            }
        }

        private void HandleButtonDown(HamsterButtonType buttonType)
        {
            switch (buttonType)
            {
                case HamsterButtonType.Main:
                    MainButtonPressed?.Invoke();
                    break;
                case HamsterButtonType.UpgradePerClick:
                    UpgradePerClickButtonPressed?.Invoke();
                    break;
                case HamsterButtonType.UpgradePerTime:
                    UpgradePerTimeButtonPressed?.Invoke();
                    break;
            }
        }

        private void Awake()
        {
            _presenter = new HamsterPresenter(this);
        }

        private void OnEnable()
        {
            _buttonComponents.ForEach(button => button.OnButtonUpClicked += HandleButtonDown);
            
            _presenter.Enable();
        }

        private void OnDisable()
        {
            _buttonComponents.ForEach(button => button.OnButtonUpClicked -= HandleButtonDown);
            
            _presenter.Disable();
        }

        private void Update()
        {
            Updated?.Invoke();
        }
    }
}