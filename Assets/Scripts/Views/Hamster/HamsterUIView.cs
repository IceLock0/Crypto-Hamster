using System;
using Presenters.Hamster;
using TMPro;
using UnityEngine;

namespace Views.Hamster
{
    public class HamsterUIView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counterTMP;

        public event Action OnUpdate;
        
        private HamsterPresenter _presenter;

        private HamsterOnClickButton _button;

        private const float ScaleFactor = 1.3f;
        
        public void SetCounterText(double value)
        {
            _counterTMP.text = $"{value:f10}";
        }

        private void Awake()
        {
            _button = GetComponent<HamsterOnClickButton>();
        }

        private void Start()
        {
            _presenter = new HamsterPresenter(this);
        }

        private void Update()
        {
            OnUpdate?.Invoke();
        }
        
        private void DownClicked()
        {
            gameObject.transform.localScale /= ScaleFactor;
        }

        private void UpClicked()
        {
            gameObject.transform.localScale *= ScaleFactor;

            _presenter.AddMoneyPerClick();
        }

        private void OnEnable()
        {
            _button.OnButtonDownClicked += DownClicked;
            _button.OnButtonUpClicked += UpClicked;
        }

        private void OnDisable()
        {
            _button.OnButtonDownClicked -= DownClicked;
            _button.OnButtonUpClicked -= UpClicked;
        }
    }
}