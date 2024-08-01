using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Enums;
using Model.Computer;
using Model.Crypto;
using Model.Wallet;
using Presenters.ComputerCryptoChanger;
using Presenters.ComputerParameterChange;
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
        private CryptoModel _targetCryptoModel;
        public ComputerMinerPresenter(ComputerModel computerModel, List<ComputerConfig> computerConfigs, ComputerRepairPresenter computerRepairPresenter, 
            WalletModel walletModel) : 
            base(computerModel, computerConfigs, computerRepairPresenter)
        {
            InvariantChecker.CheckObjectInvariant(walletModel );
            _walletModel = walletModel;
        }

        protected override async UniTask ChangeComputerParameter()
        {
            while (ComputerModel.Quality > 0)
            {
                //Debug.Log($"Rate : {_targetCryptoModel.Rate}\n Quality : {ComputerModel.Quality}");
                _walletModel.AddCurrencyAmountPerValue(CryptoEnumToTypeService.CryptoToType(_targetCryptoModel.Currency), _targetCryptoModel.Rate * ComputerModel.Quality);
                await UniTask.Delay((int)(_targetCryptoModel.PerTime * 1000));
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
        }

        public override void Disable()
        {
            base.Disable();
            ComputerModel.CurrentCurrencyChanged -= UpdateCryptoModel;
        }

        private void UpdateCryptoModel()
        {
            _targetCryptoModel =
                ComputerConfig.CryptoModels.First(x =>
                    CryptoEnumToTypeService.CryptoToType(x.Currency) == ComputerModel.CurrentCurrency);
        }
    }
}