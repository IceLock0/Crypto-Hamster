using UnityEngine;

namespace ScriptableObjects
{

    [CreateAssetMenu(fileName = "Repair Kit", menuName = "Shop/Repair kit", order = 0)]
    public class RepairKit : ScriptableObject
    {
        [SerializeField] private float _repairPower;

        public float RepairPower => _repairPower;
    }
}