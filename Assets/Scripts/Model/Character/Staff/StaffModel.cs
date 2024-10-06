using System;
using Enums.Staff;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

namespace Model.Staff
{
    public abstract class StaffModel
    {
        public StaffModel(StaffConfig staffConfig, NavMeshAgent agent)
        {
            Agent = agent;

            HasWork = false;

            SetParameter(staffConfig);
        }
        public SpeedModel SpeedModel { get; private set; }

        public float Acceleration { get; private set; }

        public float Price { get; private set; }
        public StaffUpgradeType StaffUpgradeType { get; private set; }

        public float RelaxTime { get; private set; }
        public float Efficiency { get; private set; }
        public float ValueReaction { get; private set; }
        public float JobSpeed { get; private set; }

        public Transform SourcePoint { get; private set; }

        public NavMeshAgent Agent { get; }

        public int CompletedUnits { get; set; }

        public bool HasWork { get; private set; }

        public Vector3 DestinationPoint { get; protected set; }

        public void SetUpgradeType(StaffUpgradeType staffUpgradeType, StaffConfig staffConfig)
        {
            if (!Enum.IsDefined(typeof(StaffUpgradeType), staffUpgradeType))
                throw new ArgumentOutOfRangeException("The upgrade type is maximum.");

            StaffUpgradeType = staffUpgradeType;
            
            SetParameter(staffConfig);
        }

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

        private void SetParameter(StaffConfig staffConfig)
        {
            SetStaffParameter(staffConfig);
            SetAgentParameter();
        }

        private void SetStaffParameter(StaffConfig staffConfig)
        {
            SpeedModel = new SpeedModel(staffConfig);

            Acceleration = staffConfig.Acceleration;

            Price = staffConfig.Price;

            RelaxTime = staffConfig.RelaxTime;
            Efficiency = staffConfig.Efficiency;
            ValueReaction = staffConfig.ValueReaction;
            JobSpeed = staffConfig.JobSpeed;

            SourcePoint = staffConfig.SourcePoint;
        }

        private void SetAgentParameter()
        {
            Agent.speed = SpeedModel.CurrentSpeed;
            Agent.angularSpeed = SpeedModel.AngularSpeed;
            Agent.acceleration = Acceleration;
        }
    }
}