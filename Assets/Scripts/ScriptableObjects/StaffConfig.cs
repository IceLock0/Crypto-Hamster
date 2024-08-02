using UnityEngine;

namespace ScriptableObjects
{
   // [CreateAssetMenu(fileName = "Staff config", menuName = "Configs/Staff", order = 0)]
    public class StaffConfig : CharacterConfig
    {
        [SerializeField] private float _acceleration;
        [SerializeField] private string _name;
        [SerializeField] private float _price;
        [SerializeField] private Transform _sourcePoint;
        [SerializeField] private float _relaxTime;
        [SerializeField] private float _efficiency;
        [SerializeField] private float _checkerTime;
        public float Acceleration => _acceleration;
        public string Name => _name;
        public float Price => _price;
        public Transform SourcePoint => _sourcePoint;
        public float RelaxTime => _relaxTime;
        public float Efficiency => _efficiency;
        public float CheckerTime => _checkerTime;
    }
}