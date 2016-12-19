using UnityEngine;
using Zenject;

public class zenject_VECTOR3_MANAGER_ : MonoInstaller {
    public override void InstallBindings() {
        Container.BindAllInterfaces<VECTOR3_MANAGER_subContainer>().To<VECTOR3_MANAGER_subContainer>().AsSingle();
    }
}