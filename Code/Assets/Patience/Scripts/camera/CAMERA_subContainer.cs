using Zenject;

public class CAMERA_subContainer : ITickable {
    readonly CAMERA_ cameraReference;
    readonly FORGE_ forgeReference;

    public CAMERA_subContainer(FORGE_ injectedForgeReference, CAMERA_ injectedCameraValue) {
        forgeReference = injectedForgeReference;
        cameraReference = injectedCameraValue;
    }

    public void Tick() {
        cameraReference.FUNCTION_checkVectorFromSelf();

        cameraReference.FUNCTION_checkMouseInput(forgeReference);
    }
}