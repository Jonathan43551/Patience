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
        cameraReference.button_home_CameraPosition0();
        cameraReference.button_home_CameraPosition1();
        cameraReference.button_home_CameraPosition2();

        cameraReference.checkVectorFromSelf();
    }
}
