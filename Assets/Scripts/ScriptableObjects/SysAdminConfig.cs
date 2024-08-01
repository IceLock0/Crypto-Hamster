using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "SysAdmin config", menuName = "Configs/SysAdmin", order = 0)]
    public class SysAdminConfig : StaffConfig
    {
        [SerializeField] private float _repairSpeed;
        [SerializeField] private float _fatigueValueReaction;
        [SerializeField] private float _efficiency;
        [SerializeField] private float _relaxTime;
        [SerializeField] private float _checkerTime;
        
        public float RepairSpeed => _repairSpeed;
        public float FatigueValueReaction => _fatigueValueReaction;
        public float Efficiency => _efficiency;
        public float RelaxTime => _relaxTime;
        public float CheckerTime => _checkerTime;
    }
}