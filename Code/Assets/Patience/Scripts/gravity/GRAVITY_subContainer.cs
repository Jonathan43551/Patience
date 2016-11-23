using Zenject;

public class GRAVITY_subContainer : ITickable
{
    readonly GRAVITY_ gravityReference;

    public GRAVITY_subContainer(GRAVITY_ injectedGravityValue)
    {
        gravityReference = injectedGravityValue;
    }
    
    public void Tick()
    {
        gravityReference.addYGravity();
        gravityReference.subtractYGravity();
    }
}
