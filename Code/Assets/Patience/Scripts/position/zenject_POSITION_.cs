using UnityEngine;
using Zenject;

public class zenject_POSITION_ : MonoInstaller {
    public override void InstallBindings() {
        Container.BindAllInterfaces<POSITION_subContainer>().To<POSITION_subContainer>().AsSingle();
    }
}