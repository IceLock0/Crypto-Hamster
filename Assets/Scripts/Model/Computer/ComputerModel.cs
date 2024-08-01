using System;
using UnityEngine;
using Enums;
using Presenters.Currency;
using Utils;
using Utils.EnumToTypeService;
using Views.Currency;
using Views.Wallet.Association_dropdown;

namespace Model.Computer
{
    public class ComputerModel
    {
        public ComputerModel(int startComputerType, float startQuality, Vector3 position)
        {
            ChangeCurrentCurrency(CryptoCurrencyIndices.Bitcoin);
            ChangeType(startComputerType);
            ChangeQuality(startQuality);

            Position = position;
        }

        public Vector3 Position { get; private set; }

        public ComputerType ComputerType { get; private set; }
        public float Quality { get; private set; }

        public Type CurrentCurrency { get; private set; }

        public event Action<ComputerType> ComputerTypeChanged;
        public event Action CurrentCurrencyChanged;

        public event Action<ComputerModel> QualityChanged;

        public void ChangeType(int typeNum)
        {
            if (!Enum.IsDefined(typeof(ComputerType), typeNum))
                throw new ArgumentOutOfRangeException();
            ComputerType = (ComputerType) typeNum;
            ComputerTypeChanged?.Invoke(ComputerType);
        }

        public void ChangeCurrentCurrency(CryptoCurrencyIndices currency)
        {
            if (CryptoEnumToTypeService.CryptoToType(currency) == typeof(Cash) || CryptoEnumToTypeService.CryptoToType(currency) == typeof(Hamster))
                throw new ArgumentOutOfRangeException();
            CurrentCurrency = CryptoEnumToTypeService.CryptoToType(currency);
            CurrentCurrencyChanged?.Invoke();
        }

        public void ChangeQuality(float targetQuality)
        {
            InvariantChecker.CheckPercentageInvariant(targetQuality);
            Quality = targetQuality;
            QualityChanged?.Invoke(this);
        }
    }
}