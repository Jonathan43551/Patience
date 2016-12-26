using UnityEngine;
using Zenject;

public class POSITION_installer : MonoInstaller {
    public override void InstallBindings() {
        //Container.Bind<POSITION_>().AsSingle();
        Container.BindAllInterfacesAndSelf<POSITION_>().AsSingle();
    }
}