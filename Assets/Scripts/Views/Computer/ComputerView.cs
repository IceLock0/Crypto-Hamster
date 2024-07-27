using System;
using Presenters.Computer;
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
        
        [Inject]
        public void Initialize(IComputerFabric computerFabric)
        {
            _computerPresenter = new ComputerPresenter(_buyButtonView, computerFabric, this,_computerSpawnPoint.position, _computerSpawnPoint);
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

        /*private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(transform.position, new Vector3(1f, 1.6645f, 2.3023f));
        }*/
    }
}