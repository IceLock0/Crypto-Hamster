using System.Collections.Generic;
using System.Linq;
using Model.Computer;
using Presenters.Character.Staff;
using Presenters.Computer;
using Presenters.Room;
using ScriptableObjects;
using UnityEngine.AI;
using Utils;
using NavMeshSurface = Unity.AI.Navigation.NavMeshSurface;

namespace Presenters.Staff.SysAdmin
{
    public class SysAdminPresenter : StaffPresenter
    {
        private readonly NavMeshSurface _navMeshSurface;
        private readonly List<ComputerBuilderPresenter> _computerBuilderPresenters;


        public SysAdminPresenter(StaffConfig staffConfig, NavMeshAgent navMeshAgent,
            ContaminationPresenter contaminationPresenter, List<ComputerBuilderPresenter> computerBuilderPresenters,
            NavMeshSurface navMeshSurface) : base(staffConfig, navMeshAgent, contaminationPresenter)
        {
            InvariantChecker.CheckObjectInvariant(staffConfig, navMeshAgent, contaminationPresenter, computerBuilderPresenters, navMeshSurface);

            _navMeshSurface = navMeshSurface;

            _computerBuilderPresenters = computerBuilderPresenters;
            
            var computerModels = _computerBuilderPresenters.Select(presenter => presenter.Model).ToList();
            
            
        }
    }
}