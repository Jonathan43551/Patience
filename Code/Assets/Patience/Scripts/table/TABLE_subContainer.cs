using Zenject;

public class TABLE_subContainer : ILateTickable {
    readonly TABLE_ tableReference;

    public TABLE_subContainer(TABLE_ injectedGravityValue) {
        tableReference = injectedGravityValue;
    }

    public void LateTick() {
        tableReference.FUNCTION_checkForInput();
    }
}
