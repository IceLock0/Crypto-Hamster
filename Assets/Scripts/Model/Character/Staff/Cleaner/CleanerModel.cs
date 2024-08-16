using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using Views.Staff.Cleaner;
using System.Collections.Generic;

namespace Model.Staff.Cleaner
{
    public class CleanerModel : StaffModel
    {
        public CleanerModel(StaffConfig cleanerConfig, NavMeshAgent agent, List<CleanerView.CleaningPoint> cleaningPoints) : base(cleanerConfig, agent)
        {
            CleaningPoints = cleaningPoints;
        }
        
        public List<CleanerView.CleaningPoint> CleaningPoints { get; }
        
        public CleanerView.CleaningPoint CurrentCleaningPoint { get; private set; }

        public float LastContaminationValue { get; set; }

        public void UpdateCleaningPoint(NavMeshPath path)
        {
            if (CurrentCleaningPoint != null)
                return;
            
            var isPointCorrect = false;

            while (!isPointCorrect)
            {
                CurrentCleaningPoint = CleaningPoints[Random.Range(0, CleaningPoints.Count)];

                NavMesh.SamplePosition(
                    Random.insideUnitSphere * CurrentCleaningPoint.PointRadius + CurrentCleaningPoint.PointTransform.position,
                    out var hit,
                    CurrentCleaningPoint.PointRadius, NavMesh.AllAreas);

                Agent.CalculatePath(hit.position, path);

                isPointCorrect = path.status == NavMeshPathStatus.PathComplete;
            }

            DestinationPoint = CurrentCleaningPoint.PointTransform.position;
        }

        public float GetTimeToClean(float contamination) => GetTimeForJob(contamination);

        public override void RemoveProcessedData()
        {
            CurrentCleaningPoint = null;
        }
    }
}