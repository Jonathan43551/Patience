using UnityEngine;
using System.Collections;
using Zenject;

public class TestInstaller : MonoInstaller {
    
    public override void InstallBindings()
    {
        //Container.Bind<GRAVITY_INTERFACE>().To<GRAVITY_>().AsSingle();
        //Container.Bind<GRAVITY_INTERFACE>().To<GRAVITY_>().AsSingle();

        Container.Bind<string>().FromInstance("Hello World!");
        Container.Bind<TestRunner>().NonLazy();

    }



}


