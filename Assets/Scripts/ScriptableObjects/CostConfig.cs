using UnityEngine;

namespace ScriptableObjects
{

    [CreateAssetMenu(fileName = "Cost config", menuName = "Configs/Costs", order = 0)]
    public class CostConfig : ScriptableObject
    {
        [SerializeField] private float _pcSlotPrice;

        public float PCSlotPrice => _pcSlotPrice;
    }

}