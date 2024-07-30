using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Presenters.Electricity;
using UnityEngine;
using UnityEngine.UI;

namespace Views.UI.Electricity
{
    public class ElectricityUIBarView : MonoBehaviour
    {
        [SerializeField] private Image _electricityImage;
        [SerializeField] private GameObject _noElectricityNotification;

        private ElectricityPresenter _presenter;
        
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
        
        private void Awake()
        {
            InitStartValues();
            
            _presenter = new ElectricityPresenter(this);
        }

        private void InitStartValues()
        {
            _electricityImage.gameObject.SetActive(true);
            _electricityImage.fillAmount = 1.0f;
            
            _noElectricityNotification.gameObject.SetActive(false);
        }
    }
}