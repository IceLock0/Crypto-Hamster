using TMPro;
using UnityEngine;

namespace Views.Wallet
{
    public class CashWalletUIView : WalletUIView
    {
        [SerializeField] private TextMeshProUGUI _currencyText;

        private void Start()
        {
            TimeBetweenAdding = 0.5f;
            CurrencyPerSecond = 1.0f;
            
        }

        public override void SetCurrencyAmountText(float amount)
        {
            _currencyText.text = "Cash: " + amount.ToString("#.###") + " $";
        }

        public void AddCurrencyAmount()
        {
            throw new System.NotImplementedException();
        }
    }
}