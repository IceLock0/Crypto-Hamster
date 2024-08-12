using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Cleaner config", menuName = "Configs/Cleaner", order = 0)]
    public class CleanerConfig : StaffConfig
    {
        [SerializeField] private float _cleanSpeed;
        [SerializeField] private float _contaminationValueReaction;
        
        public float CleanSpeed => _cleanSpeed;
        public float ContaminationValueReaction => _contaminationValueReaction;
    }
}