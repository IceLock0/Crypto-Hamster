using System.Collections.Generic;
using Presenters.Character.Staff;
using Presenters.Computer;
using Presenters.Room;
using ScriptableObjects;
using UnityEngine.AI;
using NavMeshSurface = Unity.AI.Navigation.NavMeshSurface;

namespace Presenters.Staff.SysAdmin
{
    public class SysAdminPresenter : StaffPresenter
    {
        public SysAdminPresenter(StaffConfig staffConfig, NavMeshAgent navMeshAgent,
            ContaminationPresenter contaminationPresenter, List<ComputerBuilderPresenter> computerBuilderPresenters,
            NavMeshSurface navMeshSurface) : base(staffConfig, navMeshAgent, contaminationPresenter)
        {
        }
    }
}