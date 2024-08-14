using System.Collections.Generic;
using Presenters.Room;
using ScriptableObjects;
using UnityEngine.AI;
using Utils;
using Views.Staff.Cleaner;

namespace Presenters.Character.Staff.Cleaner
{
    public class CleanerPresenter : StaffPresenter
    {
        private readonly List<CleanerView.CleaningPoint> _cleaningPoints;
        
        public CleanerPresenter(StaffConfig staffConfig, NavMeshAgent navMeshAgent,
            ContaminationPresenter contaminationPresenter, List<CleanerView.CleaningPoint> cleaningPoints)
            : base(staffConfig, navMeshAgent, contaminationPresenter)
        {
            InvariantChecker.CheckObjectInvariant(staffConfig, navMeshAgent, contaminationPresenter, cleaningPoints);
            
            _cleaningPoints = cleaningPoints;
        }
    }
}