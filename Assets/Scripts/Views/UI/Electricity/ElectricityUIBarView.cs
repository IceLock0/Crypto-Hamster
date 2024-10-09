using System;
using DG.Tweening;
using Model.Electricity;
using Model.Wallet;
using Presenters.Electricity;
using UnityEngine;
using UnityEngine.UI;
using Views.Empty.Electricity;
using Views.UI.Electricity.ButtonPayment;
using Zenject;

namespace Views.UI.Electricity
{
    public class ElectricityUIBarView : MonoBehaviour
    {
        private ElectricityBarPresenter _barPresenter;

        [Inject]
        public void Initialize(ElectricityUIButtonPayment paymentButton, ElectricityFillView electricityFillView, ElectricityIconView electricityIconView, WalletModel walletModel, ElectricityModel electricityModel)
        {
            _barPresenter = new ElectricityBarPresenter(this, paymentButton, walletModel, electricityModel, electricityIconView, electricityFillView);
        }

        private void Start()
        {
            _barPresenter.InitializeImages();
        }

        private void OnEnable()
        {
            _barPresenter.Enable();
        }

        private void OnDisable()
        {
            _barPresenter.Disable();
        }
        public void ChangeFillAmount(Image targetImage, float value, float duration)
        {
            targetImage.DOFillAmount(value, duration);
        }

        private void InitStartValues(Image targetImage)
        {
            targetImage.fillAmount = 1.0f;
        }
    }
}