using System;
using System.Collections.Generic;
using Enums.Staff;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Views.UI.Phone.Apps.Staff.MainApp.ArrowButtons;

namespace Views.UI.Phone.Apps.Staff.MainApp
{
    public class StaffSelectionHandlerView : MonoBehaviour
    {
        [SerializeField] private PhoneStaffLeftArrowButtonView _leftArrowButton;
        [SerializeField] private PhoneStaffRightArrowButtonView _rightArrowButton;
        [SerializeField] private Image _staffImage;
        [SerializeField] private Sprite[] _staffSprites;
        [SerializeField] private TextMeshProUGUI _buyUpgradeText;

        private int _currentIndex = 0;

        private readonly Dictionary<StaffType, StaffState> _staffStates = new();

        public StaffState GetCurrentStaffState() => _staffStates[(StaffType) _currentIndex];
        public StaffType GetCurrentStaffType() => (StaffType) _currentIndex;

        public void SetStaffState(StaffType staffType, StaffState staffState)
        {
            _staffStates[staffType] = staffState;
            
            ShowInfo();
        }
        
        private void Awake()
        {
            _staffStates.Add(StaffType.Admin, StaffState.NotBought);
            _staffStates.Add(StaffType.SysAdmin, StaffState.NotBought);
            _staffStates.Add(StaffType.Cleaner, StaffState.NotBought);
            
            UpdateSprite();
        }

        private void OnEnable()
        {
            _leftArrowButton.Clicked += OnLeftArrowButtonClicked;
            _rightArrowButton.Clicked += OnRightArrowButtonClicked;
        }

        private void OnDisable()
        {
            _leftArrowButton.Clicked -= OnLeftArrowButtonClicked;
            _rightArrowButton.Clicked -= OnRightArrowButtonClicked;
        }

        private void OnLeftArrowButtonClicked()
        {
            _currentIndex = (_currentIndex - 1 + _staffSprites.Length) % _staffSprites.Length;

            UpdateSprite();
        }

        private void OnRightArrowButtonClicked()
        {
            _currentIndex = (_currentIndex + 1) % _staffSprites.Length;

            UpdateSprite();
        }

        private void UpdateSprite()
        {
            _staffImage.sprite = _staffSprites[_currentIndex];

            ShowInfo();
        }

        private void ShowInfo()
        {
            string text = "";

            switch (GetCurrentStaffState())
            {
                case StaffState.NotBought:
                    text = "КУПИТЬ";
                    break;
                case StaffState.Bought:
                    text = "УЛУЧШИТЬ";
                    break;
            }

            _buyUpgradeText.text = text;
        }
    }
}