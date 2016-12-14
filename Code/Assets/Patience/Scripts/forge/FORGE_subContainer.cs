using Zenject;

public class FORGE_subContainer : ILateTickable {

    readonly FORGE_ forgeReference;

    public FORGE_subContainer(FORGE_ injectedForgeValue) {
        forgeReference = injectedForgeValue;
    }

    public void LateTick() {
        forgeReference.FUNCTION_checkForInput();
    }
}