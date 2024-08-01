using System.Collections.Generic;
using Model.Computer;
using Utils;
using Views.UI.ComputerControlPanel.ChangeCryptoButton;
using Views.Wallet.Association_dropdown;

namespace Presenters.Computer.ComputerCryptoChanger
{
    public class ComputerCryptoChangePresenter
    {
        private readonly ComputerModel _computerModel;
        private readonly List<ChangeCryptoButtonView> _changeCryptoButtonViews;
        public ComputerCryptoChangePresenter(ComputerModel computerModel, List<ChangeCryptoButtonView> changeCryptoButtonViews)
        {
            InvariantChecker.CheckObjectInvariant(computerModel, changeCryptoButtonViews);
            
            _computerModel = computerModel;
            _changeCryptoButtonViews = changeCryptoButtonViews;
        }

        public void Enable()
        {
            foreach (var view in _changeCryptoButtonViews)
            {
                view.CryptoChanged += OnCryptoChanged;
            }
            
        }

        public void Disable()
        {
            foreach (var view in _changeCryptoButtonViews)
            {
                view.CryptoChanged -= OnCryptoChanged;
            }
        }

        private void OnCryptoChanged(CryptoCurrencyIndices targetCryptoCurrency)
        {
            _computerModel.ChangeCurrentCurrency(targetCryptoCurrency);
        }
    }
}