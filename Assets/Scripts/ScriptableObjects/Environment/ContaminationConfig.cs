using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Contamination config", menuName = "Configs/Contamination config", order = 0)]
    public class ContaminationConfig : ScriptableObject
    {
        [SerializeField] private float _maxContamination;
        [SerializeField] private float _secondsDelay;
        [SerializeField] private float _increaseValue;

        public float MaxContamination => _maxContamination;
        public float SecondsDelay => _secondsDelay;
        public float IncreaseValue => _increaseValue;

    }
}