﻿using System;
using System.Collections.Generic;
using Model.Wallet;
using Presenters.Currency;
using Presenters.Wallet;
using TMPro;
using UnityEngine;
using Views.Currency;
using Views.UI.Wallet;
using Zenject;


namespace Views.Wallet
{
    public class WalletUIView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _cashText;
        [SerializeField] private CryptoDropDownHandler _dropDownHandler;

        private WalletPresenter _presenter;

        private Type _cryptoType;
        
        public void SetCashText(float amount)
        {
            _cashText.text = "Cash: " + $"{amount:f5}" + " $";
        }

        public void SetCryptoText()
        {
            var amount = _presenter.GetCryptoAmount(_cryptoType);
            
            _dropDownHandler.CryptoText.text = $"{amount:f8}";
        }
        

        [Inject]
        private void Initialize(WalletModel walletModel, Dictionary<Type, ICurrency> currencies)
        {
            _cryptoType = typeof(Bitcoin);
            
            _presenter = new WalletPresenter(this, walletModel, currencies);
        }
        
        private void OnEnable()
        {
            _presenter.Enable();

            _dropDownHandler.CryptoSelected += SetCryptoType;
        }
        
        private void OnDisable()
        {
            _presenter.Disable();
            
            _dropDownHandler.CryptoSelected -= SetCryptoType;
        }

        private void SetCryptoType(Type type)
        {
            _cryptoType = type;
            
            SetCryptoText();
        }
    }
}