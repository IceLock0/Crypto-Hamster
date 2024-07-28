using System;
using System.Collections.Generic;
using System.Linq;
using Presenters.Hamster;
using UnityEngine;
using Views.Hamster.Buttons;

namespace Views.Hamster
{
    public class HamsterUIView : MonoBehaviour
    {
        [SerializeField] private List<HamsterUIButtonHandler> _buttons;

        public event Action Updated;

        private HamsterPresenter _presenter;

        public void SetText(HamsterButtonType type, float value)
        {
            foreach (var button in _buttons.Where(button => button.HamsterButtonType == type))
            {
                button.SetAmountText(value);
            }
        }

        private void ButtonProcess(HamsterButtonType type)
        {
            switch (type)
            {
                case HamsterButtonType.MainButton:
                    _presenter.AddMoneyPerClick();
                    break;
                case HamsterButtonType.UpgradePerClickButton:
                    _presenter.IncreaseMoneyPerClick();
                    break;
                case HamsterButtonType.UpgradePerTimeButton:
                    _presenter.IncreaseMoneyPerTime();
                    break;
            }
        }
        
        private void Awake()
        {
            _presenter = new HamsterPresenter(this);
        }

        private void OnEnable()
        {
            _buttons.ForEach(button => button.ButtonPressed += ButtonProcess);
            
            _presenter.Enable();
        }

        private void OnDisable()
        {
            _buttons.ForEach(button => button.ButtonPressed -= ButtonProcess);
            
            _presenter.Disable();
        }

        private void Update()
        {
            Updated?.Invoke();
        }
    }
}