using UnityEngine;
using Zenject;

public class zenject_FORGE_ : MonoInstaller {
    public override void InstallBindings() {
        Container.BindAllInterfaces<FORGE_subContainer>().To<FORGE_subContainer>().AsSingle();
    }
}
