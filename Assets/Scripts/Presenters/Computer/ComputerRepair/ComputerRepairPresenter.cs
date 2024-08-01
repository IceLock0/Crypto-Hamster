using System;
using Model.Computer;
using ScriptableObjects;
using UnityEngine;
using Utils;
using Views.UI.ComputerControlPanel.RepairButton;

namespace Presenters.ComputerRepair
{
    public class ComputerRepairPresenter
    {
        private const string HighHealthException = "Unable to use repair kit due to computer healthy";
        
        private readonly RepairButtonView _repairButtonView;
        private readonly ComputerModel _computerModel;
        private readonly RepairKit _repairKit;

        public ComputerRepairPresenter(RepairButtonView repairButtonView, ComputerModel computerModel, RepairKit repairKit)
        {
            InvariantChecker.CheckObjectInvariant(repairButtonView, computerModel, repairKit);
            
            _repairButtonView = repairButtonView;
            _computerModel = computerModel;
            _repairKit = repairKit;
        }

        public event Action ComputerFixed;

        public void Enable()
        {
            _repairButtonView.RepairButtonClicked += OnRepairButtonClicked;
        }

        public void Disable()
        {
            _repairButtonView.RepairButtonClicked -= OnRepairButtonClicked;
        }

        private void OnRepairButtonClicked()
        {
            if (Math.Abs(_computerModel.Quality - 100f) < 0.1f)
                throw new ArgumentOutOfRangeException(HighHealthException);
            var targetQuality = Mathf.Clamp(_computerModel.Quality + _repairKit.RepairPower, 0f, 100f);
            _computerModel.ChangeQuality(targetQuality);
            ComputerFixed?.Invoke();
        }
    }
}