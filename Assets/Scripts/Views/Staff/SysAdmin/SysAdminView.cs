using System;
using System.Collections.Generic;
using System.Linq;
using Model.Computer;
using Presenters.Computer;
using Presenters.Staff.SysAdmin;
using ScriptableObjects;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Views.Computer;
using Zenject;

namespace Views.Staff
{
    public class SysAdminView : MonoBehaviour
    {
        [SerializeField] private List<ComputerView> _computerViews;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Unity.AI.Navigation.NavMeshSurface _surface; 
        
        private SysAdminPresenter _presenter;
        
        private SysAdminConfig _sysAdminConfig;
        
        [Inject]
        public void Initialize(SysAdminConfig sysAdminConfig)
        {
            _sysAdminConfig = sysAdminConfig;
        }

        private void OnEnable()
        {
            _presenter.Enable();
        }

        private void OnDisable()
        {
            _presenter.Disable();
        }

        private void Awake()
        {
            var presenters = _computerViews.Select(view => view.GetPresenter()).ToList();

            _presenter = new SysAdminPresenter(_sysAdminConfig, presenters, _agent, _surface);
        }
    }
}