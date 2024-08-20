using System;
using System.Collections.Generic;
using Enums;
using Unity.AI.Navigation;
using UnityEngine;
using Model.Computer;
using Presenters.Computer;

namespace Model.NavMesh
{
    public class NavMeshBuilderPresenter
    {
        private readonly NavMeshSurface _navMeshSurface;
        private readonly List<ComputerBuilderPresenter> _computerBuilderPresenters;
        
        public NavMeshBuilderPresenter(NavMeshSurface navMeshSurface, List<ComputerBuilderPresenter> computerBuilderPresenters)
        {
            _navMeshSurface = navMeshSurface;
            _computerBuilderPresenters = computerBuilderPresenters;
        }
        
        public void Enable()
        {
            foreach (var presenter in _computerBuilderPresenters)
            {
                presenter.ComputerBuilded += BuildSurface;
            }
        }
        
        public void Disable()
        {
            foreach (var presenter in _computerBuilderPresenters)
            {
                presenter.ComputerBuilded -= BuildSurface;
            }
        }
        
        private void BuildSurface(ComputerType computerType)
        {
            if(computerType == ComputerType.Common)
                _navMeshSurface.BuildNavMesh();
        }

    }
}