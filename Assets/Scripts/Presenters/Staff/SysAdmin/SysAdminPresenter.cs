using System;
using System.Collections.Generic;
using Model.Computer;
using Presenters.Computer;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

namespace Presenters.Staff.SysAdmin
{
    public class SysAdminPresenter
    {
        private readonly Queue<ComputerModel> _brokenPC;

        private readonly NavMeshAgent _agent;

        private readonly SysAdminConfig _sysAdminConfig;

        private readonly List<ComputerPresenter> _computerPresenters;
        private readonly List<ComputerModel> _computers;
        
        private float _fatigueValueReaction;
        private float _repairSpeed;

        private bool _hasWork = false;
        
        public SysAdminPresenter(SysAdminConfig sysAdminConfig, List<ComputerPresenter> computerPresenters, NavMeshAgent agent)
        {
            _brokenPC = new Queue<ComputerModel>();

            _computers = new List<ComputerModel>();

            _agent = agent;
            
            _sysAdminConfig = sysAdminConfig;

            _computerPresenters = computerPresenters;
            
            foreach (var presenter in _computerPresenters)
                _computers.Add(presenter.Model);

            InitConfigParameters();
        }

        public void Enable()
        {
            foreach (var computer in _computers)
                computer.QualityChanged += AddBrokenPC;
        }

        public void Disable()
        {
            foreach (var computer in _computers)
                computer.QualityChanged -= AddBrokenPC;
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
                throw new Exception($"Computer fatigue value = {brokenPC.Quality}, but sysadmin have {_fatigueValueReaction}");

            if(_brokenPC.Contains(brokenPC))
                throw new Exception($"Computer {brokenPC} already contained");
            
            _brokenPC.Enqueue(brokenPC);

            if(_hasWork == false)
                RepairPC();
        }

        private void RepairPC()
        {
            _agent.SetDestination(_brokenPC.Peek().Position);

            _hasWork = true;
            
            Debug.Log("Ready to repair");

            RemoveRepairedPC();
        }
        
        private void RemoveRepairedPC()
        {
            var repairedPC = _brokenPC.Dequeue();

            _hasWork = false;
            
            Debug.Log($"Computer: {repairedPC} was repaired, Quality = {repairedPC.Quality}");
        }
    }
}