using System;
using System.Collections.Generic;
using Enums.Staff;
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
        [SerializeField] private List<StaffSpriteWithTypeAssociation> _staffSprites;

        private int _currentIndex = 0;

        public event Action<StaffType> StaffTypeChanged;
        
        public StaffType GetCurrentStaffType() => (StaffType)_currentIndex;
        
        private void Awake()
        {
            UpdateInfo();
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
            _currentIndex = (_currentIndex - 1 + _staffSprites.Count) % _staffSprites.Count;

            UpdateInfo();
        }

        private void OnRightArrowButtonClicked()
        {
            _currentIndex = (_currentIndex + 1) % _staffSprites.Count;

            UpdateInfo();
        }

        private void UpdateInfo()
        {
            UpdateSprite();
        }

        private void UpdateSprite()
        {
            foreach (var staffSprite in _staffSprites)
            {
                if (staffSprite.Type == (StaffType) _currentIndex)
                    _staffImage.sprite = staffSprite.Sprite;
            }

            StaffTypeChanged?.Invoke(GetCurrentStaffType());
        }

        [Serializable]
        public class StaffSpriteWithTypeAssociation
        {
            [SerializeField] private StaffType _type;
            [SerializeField] private Sprite _sprite;

            public StaffType Type => _type;
            public Sprite Sprite => _sprite;
        }
    }
}