using UnityEngine;
using Zenject;

public class zenject_TABLE_ : MonoInstaller {
    public override void InstallBindings() {
        Container.BindAllInterfaces<TABLE_subContainer>().To<TABLE_subContainer>().AsSingle();
    }
}
