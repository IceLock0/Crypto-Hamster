using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Enums;
using Model.Computer;
using Model.Staff.SysAdmin;
using ModestTree;
using Presenters.Computer;
using Presenters.Room;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Presenters.Staff.SysAdmin
{
    public class SysAdminPresenter
    {
        private readonly SysAdminModel _sysAdminModel;

        private readonly Unity.AI.Navigation.NavMeshSurface _surface;

        private readonly List<ComputerBuilderPresenter> _computerPresenters;

        private readonly ContaminationPresenter _contaminationPresenter;
        
        private CancellationTokenSource _cts;
        
        public SysAdminPresenter(SysAdminConfig sysAdminConfig, List<ComputerBuilderPresenter> computerPresenters,
            NavMeshAgent agent, Unity.AI.Navigation.NavMeshSurface surface, ContaminationPresenter contaminationPresenter)
        {
            InvariantChecker.CheckObjectInvariant(sysAdminConfig, computerPresenters, agent, surface, contaminationPresenter);

            _computerPresenters = new List<ComputerBuilderPresenter>();
            _computerPresenters = computerPresenters;

            var computers = _computerPresenters.Select(presenter => presenter.Model).ToList();

            _sysAdminModel = new SysAdminModel(sysAdminConfig, agent, computers);

            _surface = surface;

            _cts = new CancellationTokenSource();

            _contaminationPresenter = contaminationPresenter;
            
            CheckBrokenComputersInQueue().Forget();
        }

        public void Enable()
        {
            foreach (var computer in _sysAdminModel.Computers)
                computer.QualityChanged += AddBrokenModel;

            foreach (var presenter in _computerPresenters)
                presenter.ComputerBuilded += BuildNavMesh;

            _sysAdminModel.ModelRemoved += CancelWork;

            _contaminationPresenter.ContaminationChanged += ChangeContaminationByContamination;
        }

        public void Disable()
        {
            foreach (var computer in _sysAdminModel.Computers)
                computer.QualityChanged -= AddBrokenModel;

            foreach (var presenter in _computerPresenters)
                presenter.ComputerBuilded -= BuildNavMesh;
            
            _sysAdminModel.ModelRemoved -= CancelWork;
            
            _contaminationPresenter.ContaminationChanged -= ChangeContaminationByContamination;
        }

        private void CancelWork()
        {
            _cts.Cancel();

            _cts = new CancellationTokenSource();
        }

        private void AddBrokenModel(ComputerModel brokenModel)
        {
            _sysAdminModel.AddBrokenModel(brokenModel);
        } 

        private async UniTaskVoid CheckBrokenComputersInQueue()
        {
            while (true)
            {
                await UniTask.Delay((int) (_sysAdminModel.CheckerTime * 1000));

                if (_sysAdminModel.CompletedUnits >= _sysAdminModel.Efficiency)
                    await WaitForRelax();

                if (!_sysAdminModel.BrokenModels.IsEmpty() && _sysAdminModel.HasWork == false)
                    await StartRepairProcess();
            }
        }

        private async UniTask WaitForRelax()
        {
            _sysAdminModel.Relax();

            await UniTask.Delay((int) (_sysAdminModel.RelaxTime * 1000));
        }

        private async UniTask StartRepairProcess()
        {
            _sysAdminModel.StartWork();

            try
            {
                await GoToDestination(_cts.Token);

                await RepairPC(_cts.Token);
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Repair process was canceled");
                _sysAdminModel.CompletedUnits--;
            }
            finally
            {
                _sysAdminModel.EndWork();
                
                _sysAdminModel.RemoveRepairedModel();
            
                GoToSourcePoint();
            }
        }

        private async UniTask GoToDestination(CancellationToken cancellationToken)
        {
            _sysAdminModel.Agent.SetDestination(_sysAdminModel.BrokenModels.Peek().Position);
            
            await UniTask.WaitUntil(() =>
                !_sysAdminModel.Agent.pathPending && _sysAdminModel.Agent.remainingDistance <= _sysAdminModel.Agent.stoppingDistance, cancellationToken : cancellationToken
            );
        }

        private async UniTask RepairPC(CancellationToken cancellationToken)
        {
            var timeToRepair = _sysAdminModel.GetTimeToRepair();

            await UniTask.Delay((int) (timeToRepair * 1000), cancellationToken : cancellationToken);

            _sysAdminModel.BrokenModels.Peek().ChangeQuality(100.0f);
        }

        private void GoToSourcePoint()
        {
            _sysAdminModel.Agent.SetDestination(_sysAdminModel.SourcePoint.position);
        }

        private void BuildNavMesh(ComputerType computerType)
        {
            if (computerType == ComputerType.Common)
                _surface.BuildNavMesh();
        }

        private void ChangeContaminationByContamination(float contamination)
        {
            _sysAdminModel.SpeedModel.ChangeSpeedByContamination(contamination);
        }
    }
}