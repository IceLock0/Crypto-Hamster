using Enums.Staff;
using UnityEngine;

namespace ScriptableObjects
{
    // [CreateAssetMenu(fileName = "Staff config", menuName = "Configs/Staff", order = 0)]
    public class StaffConfig : CharacterConfig
    {
        [Header("Agent")] [SerializeField] private float _acceleration;

        [Header("Buying")] 
        [SerializeField] private StaffUpgradeType _upgradeType;
        [SerializeField] private float _price;

        [Header("Job")] 
        [SerializeField] private float _relaxTime;
        [SerializeField] private float _efficiency;
        [SerializeField] private float _valueReaction;
        [SerializeField] private float _jobSpeed;
        [SerializeField] private Transform _sourcePoint;

        public float Acceleration => _acceleration;
        public StaffUpgradeType UpgradeType => _upgradeType;
        public float Price => _price;
        public float RelaxTime => _relaxTime;
        public float Efficiency => _efficiency;
        public float ValueReaction => _valueReaction;
        public float JobSpeed => _jobSpeed;
        public Transform SourcePoint => _sourcePoint;
    }
}