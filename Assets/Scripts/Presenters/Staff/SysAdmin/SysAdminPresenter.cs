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
        
        private readonly List<ComputerModel> _computers;
        
        private float _fatigueValueReaction;
        private float _repairSpeed;

        private bool _hasWork = false;
        
        public SysAdminPresenter(SysAdminConfig sysAdminConfig, List<ComputerPresenter> computerPresenters, NavMeshAgent agent, Unity.AI.Navigation.NavMeshSurface surface)
        {
            _brokenPC = new Queue<ComputerModel>();

            _computers = new List<ComputerModel>();

            _agent = agent;
            _surface = surface;
            
            _sysAdminConfig = sysAdminConfig;

            foreach (var presenter in computerPresenters)
                _computers.Add(presenter.Model);

            InitConfigParameters();
            CheckBrokenComputersInQueue().Forget();
        }

        public void Enable()
        {
            foreach (var computer in _computers)
            {
                computer.QualityChanged += AddBrokenPC;
                computer.ComputerTypeChanged += BuildNavMesh;
            }
        }

        public void Disable()
        {
            foreach (var computer in _computers)
            {
                computer.QualityChanged -= AddBrokenPC;
                computer.ComputerTypeChanged -= BuildNavMesh;
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
                throw new ArgumentOutOfRangeException($"Computer fatigue value = {brokenPC.Quality}, but sysadmin have {_fatigueValueReaction}");

            if(_brokenPC.Contains(brokenPC))
                throw new ArgumentException($"Computer {brokenPC} already contained");
            
            _brokenPC.Enqueue(brokenPC);
            
            Debug.Log($"Pc {brokenPC} added, Queue Length = {_brokenPC.Count}");
            
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
            
            Debug.Log($"Sysadming go to {currentPC.Position}");
            
            _agent.SetDestination(currentPC.Position);

            _hasWork = true;

            Debug.Log($"Agent has path: {_agent.destination}");
            
            while (_agent.hasPath)
            {
                Debug.Log("Sysadmin walk....");
            }

            Debug.Log("Ready to repair");

            currentPC.ChangeQuality(100.0f);
            
            RemoveRepairedPC();
        }
        
        private void RemoveRepairedPC()
        {
            var repairedPC = _brokenPC.Dequeue();

            _hasWork = false;
            
            Debug.Log($"Computer: {repairedPC} was repaired, Quality = {repairedPC.Quality}");
        }

        private void BuildNavMesh(ComputerType computerType)
        {
            if (computerType == ComputerType.Common)
            {
                Debug.Log("Build");
                _surface.BuildNavMesh();
                
            }
        }
            
        
    }
}