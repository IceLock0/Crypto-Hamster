using System;
using UnityEngine;
using Views.UI.ButtonUI;
using Views.Wallet.Association_dropdown;

namespace Views.UI.ComputerControlPanel.ChangeCryptoButton
{
    public class ChangeCryptoButtonView : ButtonView
    {
        [SerializeField] private CryptoCurrencyIndices _crypto;

        public event Action<CryptoCurrencyIndices> CryptoChanged;
            
        protected override void ButtonClicked()
        {
            CryptoChanged?.Invoke(_crypto);
        }
    }
}