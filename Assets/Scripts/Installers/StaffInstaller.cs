using System.Collections.Generic;
using UnityEngine;
using Views.Computer.ComputerBuilder;
using Views.Staff.Cleaner;
using Zenject;

namespace Installers
{
    public class StaffInstaller : MonoInstaller
    {
        [SerializeField] private List<CleanerView.CleaningPoint> _cleaningPoints;
        [SerializeField] private List<ComputerBuilderView> _computerViews;        
        
        public override void InstallBindings()
        {
            BindCleaningPoints();
            BindComputerViews();
        }

        private void BindCleaningPoints()
        {
            Container.Bind<List<CleanerView.CleaningPoint>>()
                .FromInstance(_cleaningPoints)
                .AsSingle()
                .NonLazy();
        }

        private void BindComputerViews()
        {
            Container.Bind<List<ComputerBuilderView>>()
                .FromInstance(_computerViews)
                .AsSingle()
                .NonLazy();
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.black;

            foreach (var patrolPoint in _cleaningPoints)
            {
                var point = patrolPoint.PointTransform;
                var radius = patrolPoint.PointRadius;
                
                Gizmos.DrawWireSphere(point.position , radius);
            }

        }
    }
}