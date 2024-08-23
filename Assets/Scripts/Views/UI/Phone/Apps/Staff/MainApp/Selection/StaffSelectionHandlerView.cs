using System;
using System.Collections.Generic;
using System.Linq;
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
        [SerializeField] private List<StaffSpriteWithTypeAssociation> _staffSprites;
        [SerializeField] private TextMeshProUGUI _buyUpgradeText;

        private int _currentIndex = 0;

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
            //UpdateText();
        }

        private void UpdateSprite()
        {
            foreach (var staffSprite in _staffSprites)
            {
                if (staffSprite.Type == (StaffType) _currentIndex)
                    _staffImage.sprite = staffSprite.Sprite;
            }
        }

        // private void UpdateText()
        // {
        //     string text = "";
        //
        //     switch (GetCurrentStaffState())
        //     {
        //         case StaffState.NotBought:
        //             text = "КУПИТЬ";
        //             break;
        //         case StaffState.Bought:
        //             text = "УЛУЧШИТЬ";
        //             break;
        //     }
        //
        //     _buyUpgradeText.text = text;
        // }

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