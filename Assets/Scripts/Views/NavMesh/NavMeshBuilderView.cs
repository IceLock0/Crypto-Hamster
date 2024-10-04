using System.Collections.Generic;
using System.Linq;
using Model.NavMesh;
using Unity.AI.Navigation;
using UnityEngine;
using Views.Computer.ComputerBuilder;
using Zenject;

namespace Views.NavMesh
{
    public class NavMeshBuilderView : MonoBehaviour
    {
        private NavMeshBuilderPresenter _presenter;
        
        [Inject]
        public void Initialize(NavMeshSurface navMeshSurface, List<ComputerBuilderView> computerBuilderViews)
        {
            var computerBuilderPresenters = computerBuilderViews.Select(view => view.GetPresenter()).ToList();
            
            _presenter = new NavMeshBuilderPresenter(navMeshSurface, computerBuilderPresenters);
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