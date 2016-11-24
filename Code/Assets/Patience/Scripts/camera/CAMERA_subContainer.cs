using Zenject;

public class CAMERA_subContainer : ITickable
{
    readonly CAMERA_ cameraReference;

    public CAMERA_subContainer(CAMERA_ injectedCameraValue)
    {
        cameraReference = injectedCameraValue;
    }

    public void Tick()
    {
        cameraReference.checkVectorFromSelf();
    }
}
