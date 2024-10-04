using System;
using Presenters.Character.Staff;
using Presenters.Room;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Views.Staff
{
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class StaffView : MonoBehaviour
    { 
        protected NavMeshAgent Agent;

        protected StaffConfig StaffConfig;

        protected ContaminationPresenter ContaminationPresenter;

        [Inject]
        public void Initialize(ContaminationPresenter contaminationPresenter)
        {
            ContaminationPresenter = contaminationPresenter;
        }

        public StaffPresenter StaffPresenter { get; protected set; }
        
        private void OnEnable()
        {
            StaffPresenter.Enable();
        }

        private void OnDisable()
        { 
            StaffPresenter.Disable();
        }
    }
}