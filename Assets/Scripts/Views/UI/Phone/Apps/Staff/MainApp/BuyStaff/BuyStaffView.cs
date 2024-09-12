    using System;
using System.Collections.Generic;
using Enums.Staff;
using Model.Wallet;
using Presenters.StaffTransaction;
    using Presenters.StaffTransaction.Buy;
    using ScriptableObjects;
using Services.Fabric.Staff;
    using TMPro;
    using UnityEngine;
using Zenject;

namespace Views.UI.Phone.Apps.Staff.MainApp.BuyStaff
{
    public class BuyStaffView : MonoBehaviour
    {
        [SerializeField] private StaffBuyUpgradeButtonView _buyButton;
        [SerializeField] private StaffSelectionHandlerView _staffSelectionrView;
        [SerializeField] private TextMeshProUGUI _buyUpgradeText;
        
        private BuyStaffPresenter _presenter;
        
        [Inject]
        public void Initialize(WalletModel walletModel, IStaffFabric staffFabric, List<SysAdminConfig> sysAdminConfigs, List<CleanerConfig> cleanerConfigs)
        {
            _presenter = new BuyStaffPresenter(walletModel, staffFabric, sysAdminConfigs, cleanerConfigs, this);
        }
        
        public void SetBuyUpgradeText(StaffType staffType)
        {
            var currentText = _presenter.GetCurrentText(staffType);
            _buyUpgradeText.text = currentText;
        }
        
        private void OnEnable()
        {
            _buyButton.Clicked += ProcessBuyUpgradeClick;
            _staffSelectionrView.StaffTypeChanged += SetBuyUpgradeText;
        }
        
        private void OnDisable()
        {
            _buyButton.Clicked -= ProcessBuyUpgradeClick;
            _staffSelectionrView.StaffTypeChanged -= SetBuyUpgradeText;
        }
        
        private void ProcessBuyUpgradeClick(StaffType staffType)
        {
            _presenter.BuyUpgrade(staffType);
        }
        
    }
}