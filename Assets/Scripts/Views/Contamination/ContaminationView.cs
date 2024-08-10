using System;
using DG.Tweening;
using Presenters.Room;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Zenject;

namespace Views.Room
{
    public class ContaminationView : MonoBehaviour
    {
        [SerializeField] private Image _contaminationImage;
        
        private ContaminationPresenter _presenter;

        [Inject]
        public void Initialize(ContaminationPresenter contaminationPresenter)
        {
            InvariantChecker.CheckObjectInvariant(contaminationPresenter);

            _presenter = contaminationPresenter;
        }

        public void ChangeContaminationFilling(float value)
        {
            _contaminationImage.DOFillAmount(value, value * 2);
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