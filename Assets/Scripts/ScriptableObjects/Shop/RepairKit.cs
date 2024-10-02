using UnityEngine;

namespace ScriptableObjects
{

    [CreateAssetMenu(fileName = "Repair Kit", menuName = "Shop/Repair kit", order = 0)]
    public class RepairKit : ShopItem
    {
        [SerializeField] private float _repairPower;

        public float RepairPower => _repairPower;

        public override string ToString()
        {
            return $"Repair kit with {_repairPower} repair power, and {Cost} cost";
        }
    }
}