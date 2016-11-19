using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindAllInterfaces<GameRunner>().To<GameRunner>().AsSingle();
    }
}