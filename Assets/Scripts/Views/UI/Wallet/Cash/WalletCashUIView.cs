using Model.Wallet;
using Presenters.Wallet.Cash;
using TMPro;
using UnityEngine;
using Zenject;

namespace Views.Wallet
{
    public class WalletCashUIView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private WalletCashPresenter _presenter;

        [Inject]
        public void Initialize(WalletModel walletModel)
        {
            _presenter = new WalletCashPresenter(this, walletModel);
        }

        public void SetText(float value)
        {
            _text.text = $"{value:0.000}";
        }

        private void OnEnable()
        {
            _presenter.Enable();
        }

        private void OnDisable()
        {
            _presenter.Disable();
        }
    }
}