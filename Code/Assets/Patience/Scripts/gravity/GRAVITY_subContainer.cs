using Zenject;

public class GRAVITY_subContainer : ILateTickable
{
    readonly GRAVITY_ gravityReference;

    public GRAVITY_subContainer(GRAVITY_ injectedGravityValue)
    {
        gravityReference = injectedGravityValue;
    }
    
    public void LateTick()
    {
        gravityReference.addGravity();
        gravityReference.subtractGravity();
    }
}
