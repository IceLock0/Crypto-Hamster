using ScriptableObjects;
using UnityEngine.AI;

namespace Model.Staff.Cleaner
{
    public class CleanerModel : StaffModel
    {
        public CleanerModel(CleanerConfig cleanerConfig, NavMeshAgent agent) : base(cleanerConfig, agent)
        {
            ContaminationValueReaction = cleanerConfig.ContaminationValueReaction;
            CleanSpeed = cleanerConfig.CleanSpeed;
        }
        
        public float ContaminationValueReaction { get; }
        public float CleanSpeed { get; }

    }
}