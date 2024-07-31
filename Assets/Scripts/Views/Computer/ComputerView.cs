using System;
using Presenters.Computer;
using Presenters.ComputerQualityChange;
using ScriptableObjects;
using Services.Fabric;
using UnityEngine;
using Views.UI.ComputerControlPanel.BuyButton;
using Zenject;

namespace Views.Computer
{
    public class ComputerView : MonoBehaviour
    {
        [SerializeField] private BuyButtonView _buyButtonView;
        [SerializeField] private Transform _computerSpawnPoint;

        private ComputerPresenter _computerPresenter;
        private ComputerQualityChangePresenter _computerQualityChangePresenter;
        
        [Inject]
        public void Initialize(IComputerFabric computerFabric, ComputerConfig computerConfig)
        {
            _computerPresenter = new ComputerPresenter(_buyButtonView, computerFabric, this,_computerSpawnPoint.position, _computerSpawnPoint);
            _computerQualityChangePresenter = new ComputerQualityChangePresenter(_computerPresenter.Model, computerConfig);
        }

        private void Start()
        {
            _computerQualityChangePresenter.TryChangingQuality();
        }

        private void OnEnable()
        {
            _computerPresenter.Enable();
        }

        private void OnDisable()
        {
            _computerPresenter.Disable();
        }

        public void DestroyComputer(GameObject gameObj)
        {
            Destroy(gameObj);
        }

        public ComputerPresenter GetComputerPresenter() => _computerPresenter;

        /*private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(transform.position, new Vector3(1f, 1.6645f, 2.3023f));
        }*/
    }
}