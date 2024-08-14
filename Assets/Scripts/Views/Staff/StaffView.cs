using System;
using Presenters.Character.Staff;
using Presenters.Room;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Views.Staff
{
    public abstract class StaffView : MonoBehaviour
    {
        [SerializeField] protected NavMeshAgent Agent;

        protected StaffPresenter StaffPresenter;

        protected StaffConfig StaffConfig;

        protected ContaminationPresenter ContaminationPresenter;
        
        [Inject]
        public void Initialize(ContaminationPresenter contaminationPresenter)
        {
            ContaminationPresenter = contaminationPresenter;
        }

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