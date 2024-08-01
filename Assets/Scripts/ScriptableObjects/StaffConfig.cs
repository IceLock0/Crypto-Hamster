using UnityEngine;

namespace ScriptableObjects
{
   // [CreateAssetMenu(fileName = "Staff config", menuName = "Configs/Staff", order = 0)]
    public class StaffConfig : CharacterConfig
    {
        [SerializeField] private string _name;
        [SerializeField] private float _price;
        [SerializeField] private Transform _sourcePoint;
        public string Name => _name;
        public float Price => _price;
        public Transform SourcePoint => _sourcePoint;
    }
}