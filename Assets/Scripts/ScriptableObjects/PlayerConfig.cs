using UnityEngine;

namespace ScriptableObjects
{

    [CreateAssetMenu(fileName = "Player config", menuName = "Configs/Player", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;

        public float MovementSpeed => _movementSpeed;
        public float RotationSpeed => _rotationSpeed;
    }

}