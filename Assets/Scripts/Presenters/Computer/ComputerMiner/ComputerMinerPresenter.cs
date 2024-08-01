using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Enums;
using Model.Computer;
using Model.Crypto;
using Model.Electricity;
using Model.Wallet;
using Presenters.Computer.ComputerParameterChange;
using Presenters.ComputerRepair;
using ScriptableObjects;
using UnityEngine;
using Utils;
using Utils.EnumToTypeService;

namespace Presenters.ComputerMiner
{
    public class ComputerMinerPresenter : ComputerParameterChangePresenter
    {
        private readonly WalletModel _walletModel;
        private readonly ElectricityModel _electricityModel;
        private CryptoModel _targetCryptoModel;
        
        public ComputerMinerPresenter(ComputerModel computerModel, List<ComputerConfig> computerConfigs, ComputerRepairPresenter computerRepairPresenter, 
            WalletModel walletModel, ElectricityModel electricityModel) : 
            base(computerModel, computerConfigs, computerRepairPresenter)
        {
            InvariantChecker.CheckObjectInvariant(walletModel, electricityModel);
            _walletModel = walletModel;
            _electricityModel = electricityModel;
        }

        protected override async UniTask ChangeComputerParameter()
        {
            while (ComputerModel.Quality > 0 && _electricityModel.CurrentElectricity > 0f)
            {
                await UniTask.Delay((int)(_targetCryptoModel.PerTime * 1000));
                _walletModel.AddCurrencyAmountPerValue(CryptoEnumToTypeService.CryptoToType(_targetCryptoModel.Currency), _targetCryptoModel.Rate * ComputerModel.Quality);
            }
        }

        protected override void OnComputerTypeChanged(ComputerType type)
        {
            base.OnComputerTypeChanged(type);
            UpdateCryptoModel();
            TryChangeComputerParameter();
        }

        public override void Enable()
        {
            base.Enable();
            ComputerModel.CurrentCurrencyChanged += UpdateCryptoModel;
            _electricityModel.ElectricityReseted += TryChangeComputerParameter;
        }

        public override void Disable()
        {
            base.Disable();
            ComputerModel.CurrentCurrencyChanged -= UpdateCryptoModel;
            _electricityModel.ElectricityReseted -= TryChangeComputerParameter;
        }

        private void UpdateCryptoModel()
        {
            _targetCryptoModel =
                ComputerConfig.CryptoModels.First(x =>
                    CryptoEnumToTypeService.CryptoToType(x.Currency) == ComputerModel.CurrentCurrency);
        }
    }
}