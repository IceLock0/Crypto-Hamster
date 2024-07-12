using UnityEngine;

namespace ScriptableObjects
{

    [CreateAssetMenu(fileName = "Player config", menuName = "Configs/Player", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private float _speed;

        public float Speed => _speed;
    }

}