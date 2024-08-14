using System;
using System.Collections.Generic;
using System.Linq;
using Model.Computer;
using Presenters.Computer;
using Presenters.Room;
using Presenters.Staff.SysAdmin;
using ScriptableObjects;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;
using Views.Computer.ComputerBuilder;
using Zenject;

namespace Views.Staff
{
    public class SysAdminView : StaffView
    {
        [SerializeField] private List<ComputerBuilderView> _computerViews;

        private NavMeshSurface _navMeshSurface;

        [Inject]
        public void Initialize(SysAdminConfig sysAdminConfig, NavMeshSurface navMeshSurface)
        {
            StaffConfig = sysAdminConfig;

            _navMeshSurface = navMeshSurface;
        }
        
        private void Awake()
        {
            var computerBuilderPresenters = _computerViews.Select(view => view.GetPresenter()).ToList();

            StaffPresenter = new SysAdminPresenter(StaffConfig, Agent, ContaminationPresenter, computerBuilderPresenters, _navMeshSurface);
        }
    }
}