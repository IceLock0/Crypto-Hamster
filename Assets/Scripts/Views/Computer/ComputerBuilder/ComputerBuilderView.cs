using Presenters.Computer;
using UnityEngine;
using Zenject;

namespace Views.Computer.ComputerBuilder
{
    public class ComputerBuilderView : MonoBehaviour
    {
        private ComputerBuilderPresenter _presenter;

        [Inject]
        public void Initialize(ComputerBuilderPresenter presenter)
        {
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

        public ComputerBuilderPresenter GetPresenter() => _presenter;
    }
}