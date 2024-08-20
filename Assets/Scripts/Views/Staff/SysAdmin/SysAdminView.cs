using System.Collections.Generic;
using System.Linq;
using Presenters.Staff.SysAdmin;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using Views.Computer.ComputerBuilder;
using Zenject;

namespace Views.Staff
{
    public class SysAdminView : StaffView
    {
        private List<ComputerBuilderView> _computerViews;

        [Inject]
        public void Initialize(SysAdminConfig sysAdminConfig, List<ComputerBuilderView> computerViews)
        {
            StaffConfig = sysAdminConfig;

            Agent = GetComponent<NavMeshAgent>();

            _computerViews = computerViews;

            var computerBuilderPresenters = _computerViews.Select(view => view.GetPresenter()).ToList();

            StaffPresenter = new SysAdminPresenter(StaffConfig, Agent, ContaminationPresenter, computerBuilderPresenters);
        }
    }
}