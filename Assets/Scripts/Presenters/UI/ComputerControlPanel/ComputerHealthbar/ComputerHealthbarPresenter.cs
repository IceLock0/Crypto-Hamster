using System;
using Model.Computer;
using Utils;
using Views.UI.ComputerControlPanel.ComputerHealthbar;
using Zenject;

namespace Presenters.UI.ComputerControlPanel.ComputerHealthbar
{
    public class ComputerHealthbarPresenter :  IDisposable
    {
        private readonly ComputerModel _computerModel;
        private readonly ComputerHealthbarView _view;
        public ComputerHealthbarPresenter(ComputerModel computerModel, ComputerHealthbarView view)
        {
            InvariantChecker.CheckObjectInvariant(computerModel,view);
            _computerModel = computerModel;
            _view = view;
            
            _computerModel.QualityChanged += OnQualityChanged;
        }
        
        ~ComputerHealthbarPresenter()
        {
            Dispose();
        }

        public void Dispose()
        {
            _computerModel.QualityChanged -= OnQualityChanged;
        }

        private void OnQualityChanged(ComputerModel model)
        {
            _view.UpdateVisual(_computerModel.Quality);
        }
    }
}