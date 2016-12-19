using Zenject;

public class VECTOR3_MANAGER_subContainer : IInitializable {
    readonly VECTOR3_MANAGER_ vector3ManagerReference;
    readonly CAMERA_ cameraReference;
    readonly FORGE_ forgeReference;
    

    public VECTOR3_MANAGER_subContainer(VECTOR3_MANAGER_ injectedVECTOR3ManagerReference, FORGE_ injectedForgeReference, CAMERA_ injectedCameraValue) {
        vector3ManagerReference = injectedVECTOR3ManagerReference;
        forgeReference = injectedForgeReference;
        cameraReference = injectedCameraValue;
    }

    public void Initialize() {
        // https://github.com/modesttree/Zenject#iinitializable-and-postinject
        //cameraReference.FUNCTION_checkVectorFromSelf();
        //cameraReference.FUNCTION_checkMouseInput(forgeReference);

        forgeReference.FUNCTION_assignVECTOR3Manager(vector3ManagerReference);
    }
}
