using UnityEngine;

namespace ScriptableObjects
{
    //[CreateAssetMenu(fileName = "Character config", menuName = "Configs/Character", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;

        public float MovementSpeed => _movementSpeed;
        public float RotationSpeed => _rotationSpeed;
    }
}