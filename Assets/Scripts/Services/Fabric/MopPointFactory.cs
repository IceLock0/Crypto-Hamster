using UnityEngine;
using Zenject;

namespace Services.Fabric
{
    public class MopPointFactory : IMopPointFabric
    {
        private const string MopPointPrefabPath = "Mop/MopPoint";

        private readonly DiContainer _container;

        private Object _mopPointPrefab;

        public MopPointFactory(DiContainer container)
        {
            _container = container;
            Load();
        }

        private void Load()
        {
            _mopPointPrefab = Resources.Load(MopPointPrefabPath);
        }

        public GameObject Create(Vector3 at, Quaternion rotation, Transform parent = null) =>
            _container.InstantiatePrefab(_mopPointPrefab, at, rotation, parent) as GameObject;
    }
}