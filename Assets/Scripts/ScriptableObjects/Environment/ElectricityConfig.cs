using UnityEngine;

namespace ScriptableObjects
{

    [CreateAssetMenu(fileName = "Electricity config", menuName = "Configs/Electricity config", order = 0)]
    public class ElectricityConfig : ScriptableObject
    {
        [SerializeField] private float _maxElectricity;
        [SerializeField] private float _secondsDelay;
        [Header("Here Will Be Saved Values")]
        [SerializeField] private float _paymentPrice;
        [SerializeField] private float _decreaseValue;

        public float MaxElectricity => _maxElectricity;
        public float SecondsDelay => _secondsDelay;
        public float PaymentPrice => _paymentPrice;
        public float DecreaseValue => _decreaseValue;

    }

}