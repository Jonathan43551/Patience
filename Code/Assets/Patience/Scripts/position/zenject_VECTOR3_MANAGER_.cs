using UnityEngine;
using Zenject;

public class zenject_VECTOR3_MANAGER_ : MonoInstaller {
    public override void InstallBindings() {
        Container.BindAllInterfaces<VECTOR3_MANAGER_subContainer>().To<VECTOR3_MANAGER_subContainer>().AsSingle();
    }
}

public class VECTOR3_MANAGER_subContainer : ITickable, IInitializable {
    readonly VECTOR3_MANAGER_ vector3ManagerReference;
    readonly CAMERA_ cameraReference;
    readonly FORGE_ forgeReference;

    public VECTOR3_MANAGER_subContainer(VECTOR3_MANAGER_ injectedVECTOR3ManagerReference, FORGE_ injectedForgeReference, CAMERA_ injectedCameraValue) {
        vector3ManagerReference = injectedVECTOR3ManagerReference;
        forgeReference = injectedForgeReference;
        cameraReference = injectedCameraValue;
    }

    public void Tick() {

        
        // https://github.com/modesttree/Zenject#iinitializable-and-postinject
        //vector3ManagerReference.FUNCTION_ask_For_Position_and_GameObject();
        ////vector3ManagerReference.FUNCTION_checkMouseInput(forgeReference);

    }

    public void Initialize() {
        vector3ManagerReference.assignCAMERA_and_FORGE_(cameraReference, forgeReference);


    }

}