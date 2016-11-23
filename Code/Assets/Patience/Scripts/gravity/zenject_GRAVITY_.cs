using UnityEngine;
using Zenject;

public class zenject_GRAVITY_ : MonoInstaller {
    public override void InstallBindings() {
        Container.BindAllInterfaces<GRAVITY_subContainer>().To<GRAVITY_subContainer>().AsSingle();
    }
}
