using DG.Tweening;
using Model.Electricity;
using Model.Wallet;
using Presenters.Electricity;
using UnityEngine;
using UnityEngine.UI;
using Views.UI.Electricity.ButtonPayment;
using Zenject;

namespace Views.UI.Electricity
{
    public class ElectricityUIBarView : MonoBehaviour
    {
        [SerializeField] private Image _electricityImage;
        [SerializeField] private GameObject _noElectricityNotification;

        private ElectricityBarPresenter _barPresenter;

        [Inject]
        public void Initialize(ElectricityUIButtonPayment paymentButton, WalletModel walletModel, ElectricityModel electricityModel)
        {
            _barPresenter = new ElectricityBarPresenter(this, paymentButton, walletModel, electricityModel);
        }
        
        private void Awake()
        {
            InitStartValues();
        }
        
        private void OnEnable()
        {
            _barPresenter.Enable();
        }

        private void OnDisable()
        {
            _barPresenter.Disable();
        }
        
        public void ChangeFillAmount(float value, float duration)
        {
            _electricityImage.DOFillAmount(value, duration);
        }

        public void ShowNotification()
        {
            _noElectricityNotification.SetActive(true);
        }

        public void HideNotification()
        {
            _noElectricityNotification.SetActive(false);
        }

        private void InitStartValues()
        {
            _electricityImage.gameObject.SetActive(true);
            _electricityImage.fillAmount = 1.0f;
            
            _noElectricityNotification.gameObject.SetActive(false);
        }

        
    }
}