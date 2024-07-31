using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "SysAdmin config", menuName = "Configs/SysAdmin", order = 0)]
    public class SysAdminConfig : StaffConfig
    {
        [SerializeField] private float _repairSpeed;
        [SerializeField] private float _fatigueValueReaction;

        public float RepairSpeed => _repairSpeed;
        public float FatigueValueReaction => _fatigueValueReaction;
    }
}