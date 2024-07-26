using UnityEngine;

namespace ScriptableObjects
{

    [CreateAssetMenu(fileName = "Camera Config", menuName = "Configs/Camera", order = 0)]
    public class CameraConfig : ScriptableObject
    {
        [SerializeField] private float _smooth;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private Vector3 _rotation;

        public float Smooth => _smooth;
        public Vector3 Offset => _offset;
        public Vector3 Rotation => _rotation;
    }

}