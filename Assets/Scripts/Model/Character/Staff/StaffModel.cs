using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

namespace Model.Staff
{
    public abstract class StaffModel
    {
        public StaffModel(StaffConfig staffConfig, NavMeshAgent agent)
        {
            RotationSpeed = staffConfig.AngularSpeed;
            Acceleration = staffConfig.Acceleration;

            SpeedModel = new SpeedModel(staffConfig.MovementSpeed);
            
            RelaxTime = staffConfig.RelaxTime;
            Efficiency = staffConfig.Efficiency;
          //  CheckerTime = staffConfig.CheckerTime;
            
            SourcePoint = staffConfig.SourcePoint;

            Agent = agent;

            HasWork = false;

            SetAgentParameter();
        }
        public float Acceleration { get; }
        public float RotationSpeed { get; }

        public float RelaxTime { get; }
        public float Efficiency { get; }
        public int CompletedUnits { get; set; }
        
        public float CheckerTime { get; }
        
        public Transform SourcePoint { get; }
        
        public NavMeshAgent Agent { get; }

        public bool HasWork { get; private set; }
        
        public SpeedModel SpeedModel { get; }

        private void SetAgentParameter()
        {
            Agent.acceleration = Acceleration;
            Agent.speed = SpeedModel.CurrentSpeed;
            Agent.angularSpeed = RotationSpeed;
        }

        public void Relax()
        {
            CompletedUnits = 0;
        }
        
        public void StartWork()
        {
            HasWork = true;
        }

        public void EndWork()
        {
            CompletedUnits++;
            HasWork = false;
        }
    }
}