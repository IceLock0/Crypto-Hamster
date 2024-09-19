using UnityEngine;

namespace ScriptableObjects
{

    [CreateAssetMenu(fileName = "Repair Kit", menuName = "Shop/Repair kit", order = 0)]
    public class RepairKit : ScriptableObject
    {
        [SerializeField] private float _repairPower;
        [SerializeField] private float _cost;

        public float RepairPower => _repairPower;
        public float Cost => _cost;
    }
}