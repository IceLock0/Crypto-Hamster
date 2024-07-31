using System.Collections.Generic;
using UnityEngine;
using Views.Computer;
using Zenject;

namespace Installers
{
    public class ComputerInstaller : MonoInstaller
    {
        // [SerializeField] private List<ComputerView> _computerViews;
        //
        // public override void InstallBindings()
        // {
        //     Container
        //         .Bind<List<ComputerView>>()
        //         .FromInstance(_computerViews)
        //         .AsTransient()
        //         .NonLazy();
        // }
    }
}