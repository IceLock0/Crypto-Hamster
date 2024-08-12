using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using Views.Staff.Cleaner;
using System.Collections.Generic;

namespace Model.Staff.Cleaner
{
    public class CleanerModel : StaffModel
    {
        public CleanerModel(CleanerConfig cleanerConfig, NavMeshAgent agent, List<CleanerView.CleaningPoint> cleaningPoints) : base(cleanerConfig, agent)
        {
            ContaminationValueReaction = cleanerConfig.ContaminationValueReaction;
            CleanSpeed = cleanerConfig.CleanSpeed;

            CleaningPoints = cleaningPoints;
        }
        
        public float ContaminationValueReaction { get; }
        public float CleanSpeed { get; }

        public List<CleanerView.CleaningPoint> CleaningPoints { get; }

        public CleanerView.CleaningPoint CurrentCleaningPoint { get; private set; }

        public void GetPoint(float contamination)
        {
            CurrentCleaningPoint = CleaningPoints[Random.Range(0, CleaningPoints.Count)];
        }

        public float GetTimeToClean(float contamination)
        {
            var contaminationToClean = contamination;

            var timeToClean = CleanSpeed / 100 * contaminationToClean;

            return timeToClean;
        }

        public void RemoveCurrentCleaningPoint()
        {
            CurrentCleaningPoint = null;
        }
    }
}