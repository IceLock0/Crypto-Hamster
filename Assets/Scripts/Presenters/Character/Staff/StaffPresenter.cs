using Presenters.Room;
using ScriptableObjects;
using UnityEngine.AI;

namespace Presenters.Character.Staff
{
    public abstract class StaffPresenter
    {
        private readonly StaffConfig _staffConfig;
        private readonly NavMeshAgent _navMeshAgent;
        private readonly ContaminationPresenter _contaminationPresenter;
        
        public StaffPresenter(StaffConfig staffConfig, NavMeshAgent navMeshAgent, ContaminationPresenter contaminationPresenter)
        {
            _staffConfig = staffConfig;
            _navMeshAgent = navMeshAgent;
            _contaminationPresenter = contaminationPresenter;
        }

        public void Enable()
        {
            
        }

        public void Disable()
        {
            
        }
    }
}