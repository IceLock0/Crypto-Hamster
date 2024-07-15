using TMPro;
using UnityEngine;

namespace Views.Wallet
{
    public class CryptoWalletUIView : WalletUIView
    {
        [SerializeField] private TMP_Dropdown _cryptoDropdown;

        private void Start()
        {
            
        }

        public override void SetCurrencyAmountText(float amount)
        {
            throw new System.NotImplementedException();
        }
    }
}