using System;
using Enums;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Services.Fabric
{
    public class ComputerFabric : IComputerFabric
    {
        private const string ComputerPath = "Computers/";
        private const string CommonComputer = ComputerPath + "CommonComputer";
        private const string RareComputer = ComputerPath + "RareComputer";
        
        private Object _commonComputer;
        private Object _rareComputer;
        private DiContainer _container;
        
        public ComputerFabric(DiContainer container)
        {
            _container = container;
            Load();
        }

        public void Load()
        {
            _commonComputer = Resources.Load(CommonComputer);
            _rareComputer = Resources.Load(RareComputer);
        }
        
        public Object Create(ComputerType type, Vector3 at, Transform parent = null)
        {
            switch (type)
            {
                case ComputerType.Common:
                    return _container.InstantiatePrefab(_commonComputer, at, Quaternion.identity,parent);
                case ComputerType.Rare:
                    return _container.InstantiatePrefab(_rareComputer, at, Quaternion.identity, parent);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}