using Presenters.ComputerMiner;
using UnityEngine;
using Utils;
using Zenject;

namespace Views.Computer.ComputerMiner
{

    public class ComputerMinerView : MonoBehaviour
    {
        private ComputerMinerPresenter _presenter;
        
        [Inject]
        public void Initialize(ComputerMinerPresenter presenter)
        {
            InvariantChecker.CheckObjectInvariant(presenter);
            _presenter = presenter;
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