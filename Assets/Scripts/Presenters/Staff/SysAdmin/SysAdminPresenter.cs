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

        private readonly List<ComputerBuilderPresenter> _computerPresenters;
        private readonly List<ComputerModel> _computers;
        
        private float _fatigueValueReaction;
        private float _repairSpeed;
        private float _efficiency;
        private float _relaxTime;
        private float _checkerTime;
        
        private float _computersFixed;
        
        private bool _hasWork = false;

        private Transform _sourcePoint;
        public SysAdminPresenter(SysAdminConfig sysAdminConfig, List<ComputerBuilderPresenter> computerPresenters, NavMeshAgent agent, Unity.AI.Navigation.NavMeshSurface surface)
        {
            _brokenPC = new Queue<ComputerModel>();

            _computerPresenters = new List<ComputerBuilderPresenter>();
            
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
            _sourcePoint = _sysAdminConfig.SourcePoint;
            _efficiency = _sysAdminConfig.Efficiency;
            _relaxTime = _sysAdminConfig.RelaxTime;
            _checkerTime = _sysAdminConfig.CheckerTime;
        }
        
        private void AddBrokenPC(ComputerModel brokenPC)
        {
            if (brokenPC.Quality > _fatigueValueReaction)
                return;

            if (_brokenPC.Contains(brokenPC))
                return;
            
            Debug.Log("PC added");
            
            _brokenPC.Enqueue(brokenPC);
        }

        private async UniTaskVoid CheckBrokenComputersInQueue()
        {
            while (true)
            {
                await UniTask.Delay((int)(_checkerTime * 1000));
                
                if (_computersFixed >= _efficiency)
                    await WaitForRelax();
                
                if(!_brokenPC.IsEmpty() && _hasWork == false)
                   StartRepairProcess();
            }
        }

        private async UniTask WaitForRelax()
        {
            Debug.Log("go to relax");
            await UniTask.Delay((int) (_relaxTime * 1000));
            Debug.Log("can work");
            _computersFixed = 0;
        }
        
        private void StartRepairProcess()
        {
            _hasWork = true;
            
            SetDestination(_brokenPC.Peek().Position).Forget();
        }
        
        private async UniTaskVoid SetDestination(Vector3 destination)
        {
            _agent.SetDestination(destination);
            
            await WaitForDestinationReached();
        }

        private async UniTask WaitForDestinationReached()
        {
            await UniTask.WaitUntil(() => 
                !_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance
            );
            
            await RepairPC();
        }

        private async UniTask RepairPC()
        {
            Debug.Log("Пришёл");

            await WaitRepairProcess();
            
            _brokenPC.Peek().ChangeQuality(100.0f);
            
            Debug.Log("Починил");

            _computersFixed++;
            
            GoToSourcePoint();

            RemoveRepairedPC();
        }

        private async UniTask WaitRepairProcess()
        {
            var qualityToRepair = 100 - _brokenPC.Peek().Quality;

            var timeToRepair = _repairSpeed / 100 * qualityToRepair;

            Debug.Log($"Время для починки = {timeToRepair}");
            
            await UniTask.Delay((int) (timeToRepair * 1000));
        }
        
        private void GoToSourcePoint()
        {
            _agent.SetDestination(_sourcePoint.position);
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