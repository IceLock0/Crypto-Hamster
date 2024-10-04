using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using Views.Staff.Cleaner;

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

            Vector3 randomPointPosition = Vector3.zero;
            
            while (!isPointCorrect)
            {
                CurrentCleaningPoint = CleaningPoints[Random.Range(0, CleaningPoints.Count)];

                UnityEngine.AI.NavMesh.SamplePosition(
                    Random.insideUnitSphere * CurrentCleaningPoint.PointRadius + CurrentCleaningPoint.PointTransform.position,
                    out var hit,
                    CurrentCleaningPoint.PointRadius, UnityEngine.AI.NavMesh.AllAreas);

                Agent.CalculatePath(hit.position, path);
                
                randomPointPosition = hit.position;
                
                isPointCorrect = path.status == NavMeshPathStatus.PathComplete;
            }
            
            DestinationPoint = randomPointPosition;
        }

        public float GetTimeToClean(float contamination) => GetTimeForJob(contamination);

        public override void RemoveProcessedData()
        {
            CurrentCleaningPoint = null;
        }
    }
}