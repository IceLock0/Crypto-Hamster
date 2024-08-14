using System.Collections.Generic;
using Presenters.Room;
using ScriptableObjects;
using UnityEngine.AI;
using Views.Staff.Cleaner;

namespace Presenters.Character.Staff.Cleaner
{
    public class CleanerPresenter : StaffPresenter
    {
        public CleanerPresenter(StaffConfig staffConfig, NavMeshAgent navMeshAgent,
            ContaminationPresenter contaminationPresenter, List<CleanerView.CleaningPoint> cleaningPoints)
            : base(staffConfig, navMeshAgent, contaminationPresenter)
        {
        }
    }
}