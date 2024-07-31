using System;
using System.Collections.Generic;
using System.Linq;
using Model.Computer;
using Presenters.Computer;
using Presenters.Staff.SysAdmin;
using ScriptableObjects;
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
        
        private SysAdminPresenter _presenter;
        
        private SysAdminConfig _sysAdminConfig;
        
        [Inject]
        public void Initialize(SysAdminConfig sysAdminConfig)
        {
            _sysAdminConfig = sysAdminConfig;
        }
        
        private void Start()
        {
            var presenters = _computerViews.Select(view => view.GetComputerPresenter()).ToList();

            _presenter = new SysAdminPresenter(_sysAdminConfig, presenters, _agent);
        }
    }
}