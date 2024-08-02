﻿using System;
using Model.Wallet;
using Presenters.Wallet.Crypto;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils.EnumToTypeService;
using Views.Wallet.Association_dropdown;
using Zenject;

namespace Views.Wallet
{
    public class WalletCryptoUIView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private TMP_Dropdown _dropdown;
        
        private WalletCryptoPresenter _presenter;
        
        public event Action<Type> CryptoSelected;

        [Inject]
        public void Initialize(WalletModel walletModel)
        {
            _presenter = new WalletCryptoPresenter(this, walletModel);
        }
        
        public void SetText(float value)
        {
            _text.text = $"{value:f12}";
        }
        
        private void GetCurrentListIndex(int index)
        {
            if (!Enum.IsDefined(typeof(CryptoCurrencyIndices), index))
                return;

            var selectedIndex = (CryptoCurrencyIndices) index;

            var type = CryptoEnumToTypeService.CryptoToType(selectedIndex);
            
            CryptoSelected?.Invoke(type);
        }

        private void OnEnable()
        {
            _presenter.Enable();

            _dropdown.onValueChanged.AddListener(GetCurrentListIndex);
        }

        private void OnDisable()
        {
            _presenter.Disable();
            
            _dropdown.onValueChanged.RemoveListener(GetCurrentListIndex);
        }
    }
}