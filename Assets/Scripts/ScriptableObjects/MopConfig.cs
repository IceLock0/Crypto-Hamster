using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Mop config", menuName = "Configs/Mop", order = 0)]
    public class MopConfig : ScriptableObject
    {
        [SerializeField] private float _timeToClean;
        [SerializeField] private float _power;

        public float TimeToClean => _timeToClean;
        public float Power => _power;
    }
}