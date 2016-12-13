using UnityEngine;
using System.Collections;
using Zenject;

public class enemyInstaller : MonoInstaller { 
    public override void InstallBindings()
    {
        Container.BindAllInterfaces<enemySpawner>().To<enemySpawner>().AsSingle();
        Container.Bind<player>().AsSingle();
        Container.BindFactory<enemy, enemy.Factory>();
    }
}
