using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

namespace Model.Staff
{
    public abstract class StaffModel
    {
        public StaffModel(StaffConfig staffConfig, NavMeshAgent agent)
        {
            AngularSpeed = staffConfig.RotationSpeed;
            Acceleration = staffConfig.Acceleration;
            MovementSpeed = staffConfig.MovementSpeed;
            
            RelaxTime = staffConfig.RelaxTime;
            Efficiency = staffConfig.Efficiency;
            CheckerTime = staffConfig.CheckerTime;
            
            SourcePoint = staffConfig.SourcePoint;

            Agent = agent;

            HasWork = false;

            SetAgentParameter();
        }
        
        public float AngularSpeed { get; }
        public float Acceleration { get; }
        public float MovementSpeed { get; }

        public float RelaxTime { get; }
        public float Efficiency { get; }
        public int CompletedUnits { get; private set; }
        
        public float CheckerTime { get; }
        
        public Transform SourcePoint { get; }
        
        public NavMeshAgent Agent { get; }

        public bool HasWork { get; private set; }

        private void SetAgentParameter()
        {
            Agent.acceleration = Acceleration;
            Agent.speed = MovementSpeed;
            Agent.angularSpeed = AngularSpeed;
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