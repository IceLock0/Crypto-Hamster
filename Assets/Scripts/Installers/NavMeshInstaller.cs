using Model.NavMesh;
using Unity.AI.Navigation;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class NavMeshInstaller : MonoInstaller
    {
        [SerializeField] private NavMeshSurface _surface;
        public override void InstallBindings()
        {
            BindNavMeshSurface();
            BindNavMeshBuilder();
        }

        private void BindNavMeshSurface()
        {
            Container
                .Bind<NavMeshSurface>()
                .FromInstance(_surface)
                .AsSingle()
                .NonLazy();
        }

        private void BindNavMeshBuilder()
        {
            Container
                .Bind<NavMeshBuilderPresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}