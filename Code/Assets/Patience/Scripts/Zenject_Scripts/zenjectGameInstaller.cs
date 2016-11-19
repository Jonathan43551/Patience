using UnityEngine;
using Zenject;

public class zenjectGameInstaller : MonoInstaller<zenjectGameInstaller>
{
    public override void InstallBindings()
    {    
        Container.Bind<GRAVITY_INTERFACE>().To<GRAVITY_>().AsSingle();
         //Container.Bind<GRAVITY_INTERFACE>().To<GRAVITY_>().AsSingle();

        Container.Bind<int>().FromInstance(1);
        Container.Bind<TestRunner>().NonLazy();
    }
}

public class TestRunner
{
    public TestRunner(int message)
    {
        Debug.Log(message);
    }
}

