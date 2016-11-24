using UnityEngine;
using Zenject;

public class zenject_CAMERA_ : MonoInstaller {
    public override void InstallBindings() {
        Container.BindAllInterfaces<CAMERA_subContainer>().To<CAMERA_subContainer>().AsSingle();
    }
}