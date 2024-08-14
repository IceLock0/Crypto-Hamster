using UnityEngine;

namespace ScriptableObjects
{
    //[CreateAssetMenu(fileName = "Character config", menuName = "Configs/Character", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [Header("Movement")]
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _angularSpeed;

        public float MovementSpeed => _movementSpeed;
        public float AngularSpeed => _angularSpeed;
    }
}