using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

namespace Model.Staff
{
    public abstract class StaffModel
    {
        public StaffModel(StaffConfig staffConfig, NavMeshAgent agent)
        {
            SpeedModel = new SpeedModel(staffConfig);
            
            Acceleration = staffConfig.Acceleration;

            Price = staffConfig.Price;
            
            RelaxTime = staffConfig.RelaxTime;
            Efficiency = staffConfig.Efficiency;
            ValueReaction = staffConfig.ValueReaction;
            JobSpeed = staffConfig.JobSpeed;
            
            SourcePoint = staffConfig.SourcePoint;

            Agent = agent;

            HasWork = false;

            SetAgentParameter();
        }
        public SpeedModel SpeedModel { get; }
        
        public float Acceleration { get; }

        public float Price { get; }

        public float RelaxTime { get; }
        public float Efficiency { get; }
        public float ValueReaction { get; }
        public float JobSpeed { get; }
        
        public Transform SourcePoint { get; }
        
        public NavMeshAgent Agent { get; }
        
        public int CompletedUnits { get; set; }

        public bool HasWork { get; private set; }

        public Vector3 DestinationPoint { get; protected set; }

        public void ResetCompletedUnits() => CompletedUnits = 0;

        public void StartWork() => HasWork = true;

        public void EndWork()
        {
            CompletedUnits++;
            HasWork = false;
        }

        public abstract void RemoveProcessedData();

        protected float GetTimeForJob(float jobUnits)
        {
            var timeToRepair = JobSpeed / 100 * jobUnits;

            return timeToRepair;
        }
        
        private void SetAgentParameter()
        {            
            Agent.speed = SpeedModel.CurrentSpeed;
            Agent.angularSpeed = SpeedModel.AngularSpeed;
            Agent.acceleration = Acceleration;
        }
    }
}