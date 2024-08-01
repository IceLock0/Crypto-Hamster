using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using Enums;
using Model.Computer;
using ModestTree;
using Presenters.Computer;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

namespace Presenters.Staff.SysAdmin
{
    public class SysAdminPresenter
    {
        private readonly Queue<ComputerModel> _brokenPC;

        private readonly Unity.AI.Navigation.NavMeshSurface _surface;
        private readonly NavMeshAgent _agent;

        private readonly SysAdminConfig _sysAdminConfig;

        private readonly List<ComputerPresenter> _computerPresenters;
        private readonly List<ComputerModel> _computers;
        
        private float _fatigueValueReaction;
        private float _repairSpeed;

        private bool _hasWork = false;
        
        public SysAdminPresenter(SysAdminConfig sysAdminConfig, List<ComputerPresenter> computerPresenters, NavMeshAgent agent, Unity.AI.Navigation.NavMeshSurface surface)
        {
            _brokenPC = new Queue<ComputerModel>();

            _computerPresenters = new List<ComputerPresenter>();
            
            _computers = new List<ComputerModel>();

            _agent = agent;
            _surface = surface;
            
            _sysAdminConfig = sysAdminConfig;

            _computerPresenters = computerPresenters;
            
            foreach (var presenter in _computerPresenters)
                _computers.Add(presenter.Model);

            InitConfigParameters();
            CheckBrokenComputersInQueue().Forget();
        }

        public void Enable()
        {
            foreach (var computer in _computers)
            {
                computer.QualityChanged += AddBrokenPC;
            }

            foreach (var presenter in _computerPresenters)
            {
                presenter.ComputerMeshCreated += BuildNavMesh;
            }
        }

        public void Disable()
        {
            foreach (var computer in _computers)
            {
                computer.QualityChanged -= AddBrokenPC;
            }
            
            foreach (var presenter in _computerPresenters)
            {
                presenter.ComputerMeshCreated -= BuildNavMesh;
            }
        }

        private void InitConfigParameters()
        {
            _agent.speed = _sysAdminConfig.MovementSpeed;
            _agent.angularSpeed = _sysAdminConfig.RotationSpeed;

            _fatigueValueReaction = _sysAdminConfig.FatigueValueReaction;
            _repairSpeed = _sysAdminConfig.RepairSpeed;
        }
        
        private void AddBrokenPC(ComputerModel brokenPC)
        {
            if (brokenPC.Quality > _fatigueValueReaction)
                return;

            if (_brokenPC.Contains(brokenPC))
                return;
            
            _brokenPC.Enqueue(brokenPC);
        }

        private async UniTask CheckBrokenComputersInQueue()
        {
            while (true)
            {
                await UniTask.Delay(5000);
                if(!_brokenPC.IsEmpty() && _hasWork == false)
                   RepairPC();
            }
        }
        
        private void RepairPC()
        {
            var currentPC = _brokenPC.Peek();

            _agent.SetDestination(currentPC.Position);

            _hasWork = true;
            
            
            // while (true)
            // {
            //     Debug.Log("Sysadmin walking....");
            // }

            Debug.Log("Пришёл   ");
            
            currentPC.ChangeQuality(100.0f);
            
            RemoveRepairedPC();
        }
        
        private void RemoveRepairedPC()
        {
            var repairedPC = _brokenPC.Dequeue();

            _hasWork = false;
        }

        private void BuildNavMesh(ComputerType computerType)
        {
            if (computerType == ComputerType.Common)
                _surface.BuildNavMesh();
        }
            
        
    }
}