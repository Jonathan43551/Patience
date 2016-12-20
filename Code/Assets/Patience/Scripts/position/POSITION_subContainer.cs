using Zenject;

public class POSITION_subContainer {
    readonly POSITION_          positionReference;
    readonly VECTOR3_MANAGER_   vector3ManagerReference;

    public POSITION_subContainer(POSITION_ injectedPositionReference, VECTOR3_MANAGER_ injectedVECTOR3ManagerReference) {
        positionReference       = injectedPositionReference;
        vector3ManagerReference = injectedVECTOR3ManagerReference;
    }
}