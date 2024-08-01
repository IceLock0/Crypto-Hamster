using Presenters.ComputerCryptoChanger;
using UnityEngine;
using Utils;
using Zenject;

namespace Views.Computer.ComputerCryptoChange
{

    public class ComputerCryptoChangeView : MonoBehaviour
    {
        private ComputerCryptoChangePresenter _presenter;
        
        [Inject]
        public void Initialize(ComputerCryptoChangePresenter presenter)
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